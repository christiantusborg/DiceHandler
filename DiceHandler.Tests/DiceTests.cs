using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DiceHandler.Tests
{
    [TestClass()]
    public class DiceTests
    {
        [TestMethod()]
        public void RollTest()
        {
            Dice dice = new Dice();
            int roll = dice.Roll(DiceType.d2);

            if (roll < 1 || roll > 2)
                Assert.Fail();
        }
    }
}

