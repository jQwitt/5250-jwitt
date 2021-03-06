﻿using System;
using System.Collections.Generic;
using System.Text;

using Mine.Models;

using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class HomeMenuItemTests
    {
        [Test]
        public void HomeMenuItem_Constructor_Valid_Default_Expect_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void HomeMenuItem_Set_Get_Valid_Default_Expect_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();
            result.Id = MenuItemType.Items;
            result.Title = "Title";


            // Reset

            // Assert
            Assert.AreEqual(MenuItemType.Items, result.Id);
            Assert.AreEqual("Title", result.Title);
        }
    }
}
