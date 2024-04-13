using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cw2_40125689;
using System.Collections.Generic;

namespace PoS_App_Test
{
    /* ServerTests.cs
    * Test class for testing the Server class. 
    * Contains test methods.
    * 
    *
    * Written by Igors Ahmetovs 10/12/15
    */
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void ServerName_WhenNameIsWhiteSpace_ShouldThrowException() // test method for testing if an exception is thrown when server's name is white space
        {
            // arrange
            Server testServer = new Server();
            string name = "   ";

            // act
            try
            {
                testServer.Name = name;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Name field is empty!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void ServerName_WhenNameIsNull_ShouldThrowException() // test method for testing if an exception is thrown when server's name is null
        {
            // arrange
            Server testServer = new Server();
            string name = null;

            // act
            try
            {
                testServer.Name = name;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Name field is empty!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void ServerName_WithCorrectName_SetsName() // test method for testing if a correct name sets the server's name properly
        {
            // arrange
            Server testServer = new Server();
            string name = "AName";
            string expected = name;

            // act
            testServer.Name = name;

            // assert
            string actual = testServer.Name;
            Assert.AreEqual(expected, actual, "Name not set correctly!");
        }

        [TestMethod]
        public void ServerStaffId_WhenValueIsLowerThanZero_ShouldThrowException() // test method for testing if an exception is thrown when staff id is a negative number
        {
            // arrange
            Server testServer = new Server();
            int id = -100;

            // act
            try
            {
                testServer.StaffId = id;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Staff ID should be a positive number!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void ServerStaffId_WhenValueIsZero_ShouldThrowException() // test method for testing if an exception is thrown when staff id is zero
        {
            // arrange
            Server testServer = new Server();
            int id = 0;

            // act
            try
            {
                testServer.StaffId = id;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Staff ID should be a positive number!", "Correct exception not thrown!");
                return;
            }

            // assert
            Assert.Fail("No exception thrown!");
        }

        [TestMethod]
        public void ServerStaffId_WithCorrectValue_SetsStaffId() // test method for testing if a staff id within range sets the server's staff id properly
        {
            // arrange
            Server testServer = new Server();
            int id = 10;
            int expected = id;

            // act
            testServer.StaffId = id;

            // assert
            int actual = testServer.StaffId;
            Assert.AreEqual(expected, actual, "Staff Id not set correctly!");
        }

        [TestMethod]
        public void ServerTakesList_WhenCreated_IsEmpty() // test method for testing if the Takes list of the server is empty upon creation
        {
            // arrange
            Server testServer = new Server();
            int expected = 0;

            // act
            int actual = testServer.Takes.Count;

            // assert
            Assert.AreEqual(expected, actual, "Takes List is not empty upon creation!");
        }

        [TestMethod]
        public void ServerAddOrder_WhenAdd_AddsOneElement() // test method for testing if the AddOrder method adds exactly one element to the Takes List
        {
            // arrange
            Server testServer = new Server();
            Order tempOrder = new Order();
            int expected = 1;

            // act
            testServer.AddOrder(tempOrder);

            // assert
            int actual = testServer.Takes.Count;
            Assert.AreEqual(expected, actual, "AddOrder() doesn't add 1 element!");
        }

        [TestMethod]
        public void ServerAddOrder_WhenAdd_CorrectlyAddsElement() // test method for testing if the AddOrder method correctly adds an order to the Takes List
        {
            // arrange
            Server testServer = new Server();
            Order tempOrder = new Order();
            tempOrder.OrderNumber = 2;
            List<Order> tempList = new List<Order>();
            tempList.Add(tempOrder);
            List<Order> expected = tempList;

            // act
            testServer.AddOrder(tempOrder);

            // assert
            List<Order> actual = testServer.Takes;
            CollectionAssert.AreEqual(expected, actual, "AddOrder() doesn't correctly add an element!");
        }
    }
}
