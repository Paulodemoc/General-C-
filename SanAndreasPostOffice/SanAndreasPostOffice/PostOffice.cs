using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SanAndreasPostOffice
{
    class PostOffice
    {
        Dictionary<string, string> Cities = new Dictionary<string, string>()
        {
            { "LS", "Los Santos" },
            { "SF", "San Fierro" },
            { "LV", "Las Venturas" },
            { "RC", "Red Country" },
            { "WS", "Whetstone" },
            { "BC", "Bone Country" }
        };

        Dictionary<string, Destination> Routes = new Dictionary<string, Destination>();

        List<string> deliveryRoutes = new List<string>();

        string filePath;

        public string FilePath { get => filePath; }

        public PostOffice()
        {
            filePath = System.AppDomain.CurrentDomain.BaseDirectory + "rotas.txt";
        }

        /// <summary>
        /// Read the city/county connections file and initialize each city/county with it's possible destinations
        /// </summary>
        /// <returns>Number of initialized cities/counties</returns>
        public int initializeDestinations()
        {
            string[] lines = Properties.Resources.trechos.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] data = line.Split(' ');
                if (data.Length == 3)
                {
                    Destination local;
                    if (Routes.ContainsKey(data[0]))
                        local = Routes[data[0]];
                    else
                    {
                        local = new Destination();
                        if (Cities.ContainsKey(data[0]))
                            local.Name = Cities[data[0]];
                        local.Abreviation = data[0];
                        Routes.Add(data[0], local);
                    }

                    if (!local.Connections.ContainsKey(data[1]))
                    {
                        try
                        {
                            local.Connections.Add(data[1], Convert.ToInt32(data[2]));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Invalid number of days from {data[0]} to {data[1]}");
                        }
                    }
                }
            }
            return Routes.Count;
        }

        /// <summary>
        /// Read the delievery file and generate the routes file with the shortest route for each one
        /// </summary>
        public void generateRoutes()
        {
            StringBuilder rotastxt = new StringBuilder();
            string[] lines = Properties.Resources.encomendas.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                deliveryRoutes.Clear();
                string[] data = line.Split(' ');
                if (data.Length == 2)
                {
                    string origin = data[0];
                    string destination = data[1];
                    Destination current = Routes[origin];

                    foreach (string conn in current.Connections.Keys)
                    {
                        string route = $"{current.Connections[conn]} {origin} {conn}";
                        deliveryRoutes.Add(route);
                        if (conn.Equals(destination))
                            break;
                        else
                            iterateConnections(Routes[conn], ref route, destination);
                    }

                    int minimumDays = -1;
                    string bestRoute = string.Empty;
                    foreach (string route in deliveryRoutes)
                    {
                        try
                        {
                            int days = Convert.ToInt32(route.Split(' ')[0]);
                            if (minimumDays == -1 || days < minimumDays)
                            {
                                minimumDays = days;
                                bestRoute = route;
                            }
                        }
                        catch
                        {

                        }
                    }
                    bestRoute = bestRoute.Substring(bestRoute.IndexOf(' ') + 1);
                    bestRoute += $" {minimumDays}";
                    rotastxt.AppendLine(bestRoute);
                }
            }
            File.WriteAllText(filePath, rotastxt.ToString());
        }

        private void iterateConnections(Destination current, ref string Route, string destination)
        {
            string[] fixRoute = { };
            int days = 0;
            if (!string.IsNullOrEmpty(Route))
            {
                fixRoute = Route.Split(' ');
                days = Convert.ToInt32(fixRoute[0]);
            }
            deliveryRoutes.Remove(Route);
            foreach (string conn in current.Connections.Keys)
            {
                if (Route.Contains(conn)) continue;
                string route = $"{days + current.Connections[conn]} ";

                for (int i = 1; i < fixRoute.Length; i++)
                {
                    route += $"{fixRoute[i]} ";
                }
                route += $"{conn}";
                deliveryRoutes.Add(route);
                if (conn.Equals(destination))
                    break;
                else
                    iterateConnections(Routes[conn], ref route, destination);
            }
        }
    }
}
