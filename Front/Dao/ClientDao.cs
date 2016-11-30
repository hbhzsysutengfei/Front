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

        public void save(ClientEntity client)
        {            
            ITransaction tx =  session.BeginTransaction();
            session.Save(client);
            tx.Commit();
            session.Close();
        }

        public void save(ClientEntity[] clients)
        {           
            ITransaction tx = session.BeginTransaction();
            foreach (var client in clients)
            {
                session.Save(client);
            }
            tx.Commit();
            session.Close();
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
                return password;                
            }
            return null;// 
            
        }

        public void UpdateClient(ClientEntity client)
        {
            ITransaction tx = session.BeginTransaction();
            session.Update(client);
            tx.Commit();
            session.Close();
        }
    }
}