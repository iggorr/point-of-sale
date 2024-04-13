using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cw2_40125689;
using System.Collections.Generic;

namespace PoS_App_Test
{
    /* DishTests.cs
    * Test class for testing the Dish class. 
    * Contains test methods.
    * 
    *
    * Written by Igors Ahmetovs 10/12/15
    */
    [TestClass]
    public class DishTests
    {
        [TestMethod]
        public void DishDescription_WhenDescriptionIsWhiteSpace_ShouldThrowException() // test method for testing if an exception is thrown when dish's description is white space
        {
            // arrange
            Dish testDish = new Dish();
            string description = "   ";

            // act
            try
            {
                testDish.Description = description;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Description field is empty!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void DishDescription_WhenDescriptionIsNull_ShouldThrowException() // test method for testing if an exception is thrown when dish's description is null
        {
            // arrange
            Dish testDish = new Dish();
            string description = null;

            // act
            try
            {
                testDish.Description = description;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Description field is empty", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void DishDescription_WithCorrectDescription_SetsDescription() // test method for testing if a correct description sets the dish's description properly
        {
            // arrange
            Dish testDish = new Dish();
            string description = "Pizzza!";
            string expected = description;

            // act
            testDish.Description = description;

            // assert
            string actual = testDish.Description;
            Assert.AreEqual(expected, actual, "Description not set correctly!");
        }

        [TestMethod]
        public void DishPrice_WhenValueIsLowerThanZero_ShouldThrowException() // test method for testing if an exception is thrown when dish price is a negative number
        {
            // arrange
            Dish testDish = new Dish();
            int price = -100;

            // act
            try
            {
                testDish.Price = price;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Price should be in range of 0 to 100000 pence!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void DishPrice_WhenValueIsZero_ShouldThrowException() // test method for testing if an exception is thrown when dish price is zero
        {
            // arrange
            Dish testDish = new Dish();
            int price = 0;

            // act
            try
            {
                testDish.Price = price;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Price should be in range of 0 to 100000 pence!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void DishPrice_WhenValueIsHigherThanBoundary_ShouldThrowException() // test method for testing if an exception is thrown when dish price is higher that upper limit
        {
            // arrange
            Dish testDish = new Dish();
            int price = 100500;

            // act
            try
            {
                testDish.Price = price;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Price should be in range of 0 to 100000 pence!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void DishPrice_WhenValueIsEqualToHigherBoundary_ShouldThrowException() // test method for testing if an exception is thrown when dish price is equal to the upper limit
        {
            // arrange
            Dish testDish = new Dish();
            int price = 100000;

            // act
            try
            {
                testDish.Price = price;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Price should be in range of 0 to 100000 pence!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void DishPrice_WhenValueWithinRange_SetsPrice() // test method for testing if a price within range sets the dish's price properly
        {
            // arrange
            Dish testDish = new Dish();
            int price = 1000;
            int expected = price;

            // act
            testDish.Price = price;

            // assert
            int actual = testDish.Price;
            Assert.AreEqual(expected, actual, "Dish Price not set correctly!");
        }

        [TestMethod]
        public void DishVegeterian_WhenTrue_SetsCorrectly() // test method for testing if a true vegetarian value sets the property correctly
        {
            // arrange
            Dish testDish = new Dish();
            bool veg = true;
            bool expected = veg;

            // act
            testDish.Vegetarian = veg;

            // assert
            bool actual = testDish.Vegetarian;
            Assert.AreEqual(expected, actual, "Dish Vegeterian not set correctly!");
        }

        [TestMethod]
        public void DishVegeterian_WhenFalse_SetsCorrectly() // test method for testing if a false vegetarian value sets the property correctly
        {
            // arrange
            Dish testDish = new Dish();
            bool veg = false;
            bool expected = veg;

            // act
            testDish.Vegetarian = veg;

            // assert
            bool actual = testDish.Vegetarian;
            Assert.AreEqual(expected, actual, "Dish Vegeterian not set correctly!");
        }

        [TestMethod]
        public void DishQuantity_WhenCreated_IsZero() // test method for testing if the quantity of the dish is zero upon creation
        {
            // arrange
            Dish testDish = new Dish();
            int expected = 0;

            // act
            int actual = testDish.Quantity;

            // assert
            Assert.AreEqual(expected, actual, "Dish Quantity doesn't equal to 0 when created!");
        }

        [TestMethod]
        public void DishQuantity_WhenSet_SetsCorrectly() // test method for testing if the quantity of the dish is set correctly
        {
            // arrange
            Dish testDish = new Dish();
            int quantity = 5;
            int expected = quantity;

            // act
            testDish.Quantity = quantity;

            // assert
            int actual = testDish.Quantity;
            Assert.AreEqual(expected, actual, "Dish Quantity not set correctly!");
        }

        [TestMethod]
        public void DishAddQuantity_WhenCalled_AddsCorrectly() // test method for testing if AddQuantity() method increases the quantity of the dish by 1
        {
            // arrange
            Dish testDish = new Dish();
            int quantity = 5;
            int expected = quantity+1;

            // act
            testDish.Quantity = quantity;
            testDish.AddQuantity();

            // assert
            int actual = testDish.Quantity;
            Assert.AreEqual(expected, actual, "Dish AddQuantity not adding correctly!");
        }

        [TestMethod]
        public void DishToString_WhenCalled_ReturnsCorrectString() // test method for testing whether the override ToString() method of the dish returns the description
        {
            // arrange
            Dish testDish = new Dish();
            string description = "Tasty pasta";
            string expected = description;

            // act
            testDish.Description = description;

            // assert
            string actual = testDish.ToString();
            Assert.AreEqual(expected, actual, "ToString() method doesn't return correct string!");

        }
        
    }
}
