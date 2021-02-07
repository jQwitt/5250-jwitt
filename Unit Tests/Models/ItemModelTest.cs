using System;
using System.Collections.Generic;
using System.Text;

using Mine.Models;

using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class ItemModelTest
    {
        [Test]
        public void ItemModel_Constructor_Valid_Default_Expect_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
