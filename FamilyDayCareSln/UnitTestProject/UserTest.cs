using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.FamilyDayCare.ClassLibrary;
using Repository.FamilyDayCare.DataAccessLayer;

namespace UnitTestProject
{
    [TestClass]
    public class UserTest
    {
        private User _user = new User()
        {
           EmailAddress ="a@a.com",
           Password="123",
           UserTypeId =0,
           IsActive=true
        };

        [TestMethod]
        public void AddUserTest()
        {
            try
            {
                DataAccessLayer db = new DataAccessLayer();
                db.AddUser(_user);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
