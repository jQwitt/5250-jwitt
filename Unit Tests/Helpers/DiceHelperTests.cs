using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Mine.Helpers;

namespace Unit_Tests.Helpers
{
    [TestFixture]
    class DiceHelperTests
    {
        [Test]
        public void RollDice_Invalid_Roll_Zero_Expect_0()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 1);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Expect_Between_1_And_6()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 6);

            // Reset

            // Assert
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }

        [Test]
        public void RollDice_Invalid_Roll_Forced_1_Expect_1()
        {
            // Arrange
            DiceHelper.ForeRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 1;

            // Act
            var result = DiceHelper.RollDice(1, 1);

            // Reset
            DiceHelper.ForeRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
