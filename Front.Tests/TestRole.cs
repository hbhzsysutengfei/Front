using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Front.Model;
using Front.Dao;

namespace Front.Tests
{
    [TestClass]
    public class TestRole
    {
        [TestMethod]
        public void TestGetRoles()
        {
            RoleDao dao = new RoleDao();
            IList<Role> roles = dao.getAllRoles();
            foreach (var role in roles)
            {
                Console.WriteLine(role.Id +"#"+role.RoleName+"#"+role.Description);
            }
        }

        [TestMethod]
        public void TestClient()
        {
            Client client = new Client();
            client.Username = "admin";
            client.Password = "123456";
            client.RealName = "张三";
            client.Role = "admin";
            client.Department = "1K";

            Console.WriteLine(client.ToString());
            client.encryptPassword();
            Console.WriteLine(client.ToString());

            Assert.IsTrue( client.validClient());
        }

        [TestMethod]
        public void TestVaidClient()
        {
            ClientDao dao = new ClientDao();

            Client client = dao.getClientByUsername("admin");
            if (client != null)
            {
                Assert.IsTrue(dao.validClient(client, "123456"));
            }
            else
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void TestResetPassword()
        {
            ClientDao dao = new ClientDao();
            string password =  dao.resetPassword("admin");
            Console.WriteLine(password);
        }


    }
}
