using System;

namespace SanAndreasPostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicializa e faz as chamadas da classe
            PostOffice poBox = new PostOffice();
            poBox.initializeDestinations();
            poBox.generateRoutes();
        }
    }
}
