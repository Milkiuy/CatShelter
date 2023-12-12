using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryUser.Tests
{
    [TestClass()]
    public class PasswordLoginCheckerTests
    {
        [TestMethod()]
        public void ValidatePasswordTest()
        {
            // Arrange.
            string password = " ";
            string login = "ivanov";
            // Act.
            bool actual = PasswordLoginChecker.ValidateUser(password,login);
            // Assert.
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void ValidateLoginTest()
        {
            // Arrange.
            string password = "1";
            string login = "ivanov123";
            // Act.
            bool actual = PasswordLoginChecker.ValidateUser(password, login);
            // Assert.
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void ValidateUserTest()
        {
            // Arrange.
            string password = "1";
            string login = "ivanov";
            // Act.
            bool actual = PasswordLoginChecker.ValidateUser(password, login);
            // Assert.
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void ValidateClickTest()
        {
            // Arrange.
            bool click = true;
            // Act.
            bool actual = PasswordLoginChecker.ValidateClick(click);
            // Assert.
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void ValidateAgeTest()
        {
            // Arrange.
            string age = "4";
            // Act.
            bool actual = PasswordLoginChecker.ValidateAge(age);
            // Assert.
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void ValidateAgeTest2()
        {
            // Arrange.
            string age = "what";
            // Act.
            bool actual = PasswordLoginChecker.ValidateAge(age);
            // Assert.
            Assert.IsFalse(actual);
        }
    }
}