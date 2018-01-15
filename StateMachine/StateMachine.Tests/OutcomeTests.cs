using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StateMachine.Tests
{
    [TestClass]
    public class OutcomeTests
    {
        [TestMethod]
        public void AssertS1Outcomes()
        {
            Machine machina = new Machine();
            string result = machina.ProcessOutcome(new char[] { 'a' });
            Assert.AreEqual("S2", result);
        }

        [TestMethod]
        public void AssertS2Outcomes()
        {
            Machine machina = new Machine();
            string result = machina.ProcessOutcome(new char[] { 'a', 'a' });
            Assert.AreEqual("S2", result);
            result = machina.ProcessOutcome(new char[] { 'a', 'b' });
            Assert.AreEqual("S1", result);
            result = machina.ProcessOutcome(new char[] { 'a', 'c' });
            Assert.AreEqual("S4", result);
        }

        [TestMethod]
        public void AssertS3Outcomes()
        {
            Machine machina = new Machine();
            string result = machina.ProcessOutcome(new char[] { 'a', 'c', 'd', 'b' });
            Assert.AreEqual("S4", result);
            result = machina.ProcessOutcome(new char[] { 'a', 'c', 'd', 'a' });
            Assert.AreEqual("S1", result);
        }

        [TestMethod]
        public void AssertS4Outcomes()
        {
            Machine machina = new Machine();
            string result = machina.ProcessOutcome(new char[] { 'a', 'c', 'd' });
            Assert.AreEqual("S3", result);
        }
    }
}
