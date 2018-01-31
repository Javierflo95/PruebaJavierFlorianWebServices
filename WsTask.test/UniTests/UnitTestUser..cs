using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WsTask.test
{
    [TestClass]
    public class UnitTestUser
    {
        private WsTareas oWsTareas = new WsTareas();

        [TestMethod]
        public void TestCreteUser()
        {
            User oUser = new User()
            {
                nombre = "Javier Unit Test",
                apellido = "Testing",
                userName = "javiTest",
                edad = "10",
                password = "12345678",
                crearTarea = "true"
            };

            oWsTareas.CreateUser(oUser);
        }

        [TestMethod]
        public void TestEditUser()
        {
            User oUser = new User()
            {
                nombre = "Javier Unit Test Edit",
                apellido = "Testing Edit",
                userName = "javiTest",
                edad = "10",
                password = "12345678",
                crearTarea = "true"
            };

            oWsTareas.EditUser(oUser);
        }

        [TestMethod]
        public User TestGetUser()
        {
            User oUser = new User()
            {
                userName = "javiTest",
            };

            return oWsTareas.GetUse(oUser);
        }

        [TestMethod]
        public void TestListUsers()
        {
            oWsTareas.ListUsers();
        }

        [TestMethod]
        public void TestGetUserLogin()
        {
            User oUser = new User()
            {
                userName = "javiTest",
                password = "12345678",
            };

            oWsTareas.GetUserLogin(oUser);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            User oUser = new User()
            {
                userName = "javiTest",
            };

            oWsTareas.DeleteUser(oUser);
        }
    }
}