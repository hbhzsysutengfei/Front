using Front.ASPX;
using Front.Model;
using Front.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Dao
{
    public class ClientDao:DataDao
    {
        public ClientDao() { }

        public string save(ClientEntity client)
        {            
            ITransaction tx =  session.BeginTransaction();
            string res = session.Save(client) as string;
            tx.Commit();
            //session.Close();
            return res;
        }

        public void save(ClientEntity[] clients)
        {           
            ITransaction tx = session.BeginTransaction();
            foreach (var client in clients)
            {
                session.Save(client);
            }
            tx.Commit();
            //session.Close();
        }

        

        public ClientEntity getClientByUsername(String username)
        {
            ClientEntity client = session.QueryOver<ClientEntity>().Where(c => c.Username == username).SingleOrDefault();
            return client;
        }

        public Boolean validClient(ClientEntity clientFromDatabase, String password)
        {
            return EncryptDecryptHelper.encryptString(password, clientFromDatabase.Salt).Equals(clientFromDatabase.Password);
        }


        public String resetPassword(String username)
        {
            ClientEntity client = getClientByUsername(username);
            if (client != null)
            {
                client.Salt = EncryptDecryptHelper.getSalt();
                string password = EncryptDecryptHelper.getRandomString();
                client.Password = EncryptDecryptHelper.encryptString(password,client.Salt);
                this.UpdateClient(client);
                return password;                
            }
            return null;//             
        }

        public void changePassword(string username,string newPassword)
        {
            ClientEntity client = getClientByUsername(username);
            if (client != null)
            {
                client.Salt = EncryptDecryptHelper.getSalt();
                client.Password = EncryptDecryptHelper.encryptString(newPassword, client.Salt);
                this.UpdateClient(client);
            }
        }
        public void UpdateClient(ClientEntity client)
        {
            ITransaction tx = session.BeginTransaction();
            session.Update(client);
            tx.Commit();
            
        }

        public void DeleteClient(string username)
        {
            ITransaction tx = session.BeginTransaction();
            ClientEntity client = this.getClientByUsername(username);
            session.Delete(client);
            tx.Commit();
        }

        public IList<ClientEntity> GetClientByDepartmentName(string departmentname)
        {
            return session.QueryOver<ClientEntity>().Where(m => m.Department.DepartmentName == departmentname).List();
        }
        public int GetClientByDepartmentNameForNumber(string departmentname)
        {
            return session.QueryOver<ClientEntity>().Where(m => m.Department.DepartmentName == departmentname).RowCount() ;
        }

        //public IList<ClientEntity> GetClientByDepartmentDesc(string desc)
        //{
        //    return session.QueryOver<ClientEntity>().Where(m => m.Department.Description == desc).List();
        //}
        //public int GetClientByDepartmentDescForNumber(string desc)
        //{
        //    return session.QueryOver<ClientEntity>().Where(m => m.Department.Description ==desc).RowCount();
        //}

        public IList<ClientEntity> GetAllClients(int pageNumber , int getNumber)
        {
            return session.QueryOver<ClientEntity>().OrderBy(m => m.Department.DepartmentName).Asc.Skip(pageNumber*getNumber).Take(getNumber).List();
        }

        public int GetAllClientForNumber()
        {
            return session.QueryOver<ClientEntity>().RowCount();
        }


        public IList<ClientEntity> GetAllAdmin()
        {
            return session.QueryOver<ClientEntity>().Where(m => m.Role.RoleName == PageInfo.RoleTypeAdmin).List();
           
        }
        public IList<ClientEntity> GetAllSuperAdmin()
        {
            return session.QueryOver<ClientEntity>().Where(m => m.Role.RoleName == PageInfo.RoleTypeSuperAdmin).List();
        }

        public IList<ClientEntity> GetClientsByUsernames(string[] names)
        {
            return session.QueryOver<ClientEntity>().WhereRestrictionOn(m => m.Username).IsIn(names).List();
        }

        public void UpdateClients(IList<ClientEntity> clients)
        {
            ITransaction tx = session.BeginTransaction();
            foreach (var client in clients)
            {
                session.Update(client);
            }
            tx.Commit();
        }
    }
}