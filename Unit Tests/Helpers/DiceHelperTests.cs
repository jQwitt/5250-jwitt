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

    }
}
