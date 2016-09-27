using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BotFactory.Common.Tools;
using BotFactory.Models;
using BotFactory.Factories;

namespace TestFactory
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Coordinates t =  new Coordinates(0,0);
            R2D2 d = new R2D2();
            if (d.Speed != 1.5) throw new Exception("pas la bonne vitesse.");
            FactoryQueueElement a = new FactoryQueueElement("tro", new Coordinates(0, 0), new Coordinates(0, 0));
            UnitFactory q = new UnitFactory(10, 10);
               q.Queue.Add(a);
            if (q.QueueTime != TimeSpan.Zero) throw new Exception("le temp n'est pas donné.");
        }
    }
}
