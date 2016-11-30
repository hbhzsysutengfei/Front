using Front.ASPX;
using Front.Dao;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Service.Client
{
    public class ClientService
    {
        private ClientDao clientDao;

        public ClientService()
        {
            clientDao = new ClientDao();
        }

        public ClientEntity ValidUser(string username, string password)
        {
            ClientEntity client = clientDao.getClientByUsername(username);
            if (client == null)
            {
                client = new ClientEntity();
                client.PageInfo = PageInfo.ClientNotExist;
                return client;
            }
            else if (clientDao.validClient(client, password) == false)
            {
               client.PageInfo = PageInfo.ClientPasswordError;
            }
            else
            {
                client.PageInfo = PageInfo.PageInfoOK;
            }
            //清楚用户的密码和salt
            client.CleanUserInfo();
            return client;
        }

        public void ChangeClientInfo()
        {

        }

        public void ChangeClientPassword()
        {

        }
        

        
    }
}