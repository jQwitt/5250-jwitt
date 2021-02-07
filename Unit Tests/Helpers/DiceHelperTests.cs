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
        public void RollDice_Valid_Roll_2_Dice_6_Expect_Between_2_And_12()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(2, 6);

            // Reset

            // Assert
            Assert.AreEqual(true, result >= 2);
            Assert.AreEqual(true, result <= 12);
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

        [Test]
        public void RollDice_Invalid_Roll_0_Dice_10_Expect_0()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 10);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_Invalid_Roll_1_Dice_0_Expect_0()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 1);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_Valid_Roll_1_Dice_10_Fixed_5_Expect_5()
        {
            // Arrange
            DiceHelper.ForeRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 5;

            // Act
            var result = DiceHelper.RollDice(1, 10);

            // Reset
            DiceHelper.ForeRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(5, result);
        }

    }
}
