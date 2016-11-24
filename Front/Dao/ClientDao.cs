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
        public void save(Client client)
        {
            ISession session = NHibernateHelper.getSession();
            ITransaction tx =  session.BeginTransaction();
            session.Save(client);
            tx.Commit();
            session.Close();
        }

        public void save(Client[] clients)
        {
            ISession session = NHibernateHelper.getSession();
            ITransaction tx = session.BeginTransaction();
            foreach (var client in clients)
            {
                session.Save(client);
            }
            tx.Commit();
            session.Close();
        }

        

        public Client getClientByUsername(String username)
        {
            ISession session = NHibernateHelper.getSession();
            return session.QueryOver<Client>().Where(c => c.Username == username).SingleOrDefault();
        }
        public Boolean validClient(Client clientFromDatabase, String password)
        {
            return EncryptDecryptHelper.encryptString(password, clientFromDatabase.Salt).Equals(clientFromDatabase.Password);
        }


        public String resetPassword(String username)
        {
            Client client = getClientByUsername(username);
            if (client != null)
            {
                client.Salt = EncryptDecryptHelper.getSalt();
                string password = EncryptDecryptHelper.getRandomString();
                client.Password = EncryptDecryptHelper.encryptString(password,client.Salt);
                return password;                
            }
            return null;// 
            
        }
    }
}