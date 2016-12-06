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
            IList<RoleEntity> roles = dao.getAllRoles();
            foreach (var role in roles)
            {
                Console.WriteLine(role.Id +"#"+role.RoleName+"#"+role.Description);
            }
        }

        [TestMethod]
        public void TestClient()
        {
            ClientEntity client = new ClientEntity();
            client.Username = "admin_k6";
            client.Password = "123456";
            client.RealName = "张三";
            client.Department = new DepartmentDao().getByName("6");
            client.Catalogs = new CatalogDao().getAll();
            client.encryptPassword();
            ClientDao clientDao = new ClientDao();
            clientDao.save(client);


            clientDao.changePassword("admin_k6", "1234");
            

            Console.WriteLine(client.ToString());
            
            Console.WriteLine(client.ToString());

            Assert.IsTrue( client.validClient());
        }

        [TestMethod]
        public void TestVaidClient()
        {
            ClientDao dao = new ClientDao();

            ClientEntity client = dao.getClientByUsername("admin_k6");
            if (client != null)
            {
                Assert.IsTrue(dao.validClient(client, "1234"));
            }
            else
            {
                Assert.Fail();
            }
        }

        public void TestDeleteClient()
        {
            ClientDao dao = new ClientDao();
            dao.DeleteClient("admin_k6");
        }
        
        [TestMethod]
        public void TestResetPassword()
        {
            ClientDao dao = new ClientDao();
            string password =  dao.resetPassword("admin");
            Console.WriteLine(password);
        }

        [TestMethod]
        public void TestAddClient()
        {
            ClientEntity client = new ClientEntity();
            client.Username = "k6_yang";
            client.Password = "123";
            client.RealName = "yangtf";
            client.Role = new RoleDao().getByName("client");
            client.Department = new DepartmentDao().getByName("6");
            client.encryptPassword();
            ClientDao clientDao = new ClientDao();
            clientDao.save(client);
        }

        [TestMethod]
        public void TestGetAllClient()
        {
            IList<ClientEntity> clients = new ClientDao().GetClientByDepartmentName("6");

        }
    }
}
