using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Tests
{
    [TestClass()]
    public class ChainTests
    {

        [TestMethod()]
        public void ChainTest1()
        {
            var chain = new Chain();
            chain.Add("Code", "Admin");

            Assert.AreEqual("Code", chain.Last.Data);
        }


        [TestMethod()]
        public void CheckTest()
        {
            var chain = new Chain();
            chain.Add("hello world", "Admin");
            chain.Add("Code block", "shwan");

            Assert.IsTrue(chain.Check());
        }

    }
}