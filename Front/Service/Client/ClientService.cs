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
                client.PageInfo = PageInfo.ClientUsernameNotExist;
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

        public void ChangeClientPassword(string username, string newPassword)
        {
            clientDao.changePassword(username, newPassword);
        }

        public IList<ClientEntity> GetAllClients(int pageNumber = 0, int getNumber = PageInfo.NumberOfClientForSuperAdmin)
        {
            IList<ClientEntity> clients = clientDao.GetAllClients(pageNumber, getNumber);
            this.CleanUserInfo(clients);
            return clients;
        }

        public int GetAllClientForNumber()
        {
            return clientDao.GetAllClientForNumber();
        }

        public int GetClientByDepartmentDescForNumber(string department)
        {
            return clientDao.GetClientByDepartmentNameForNumber(department);
        }
        public IList<ClientEntity> getClientByDepartmentDesc(String department)
        {
            return clientDao.GetClientByDepartmentName(department);
        }


        public ClientEntity GetClientByUsername(string username)
        {
            ClientEntity client = clientDao.getClientByUsername(username);
            if (client != null)
            {
                client.CleanUserInfo();
            }
            return client;
        }

        public string Save(ClientEntity client)
        {
            return clientDao.save(client);
        }

        public void AuthorizeCatalogToClients(CatalogEntity catalog,string[] usernames)
        {
            IList<ClientEntity> clients = clientDao.GetClientsByUsernames(usernames);
            foreach (var client in clients)
            {
                client.Catalogs.Add(catalog);
            }
            clientDao.UpdateClients(clients);
        }

        //public void UpdateClients(IList<ClientEntity> clients)
        //{
        //    clientDao.UpdateClients(clients);
        //}

        public string ResetPassword(string username)
        {
            return clientDao.resetPassword(username);
        }


        public IList<ClientEntity> GetAllAdmin()
        {
            IList<ClientEntity> clients = clientDao.GetAllAdmin();
            this.CleanUserInfo(clients);
            return clients;
        }
        public IList<ClientEntity> GetAllSuperAdmin()
        {
            IList<ClientEntity> clients = clientDao.GetAllSuperAdmin();
            this.CleanUserInfo(clients);
            return clients;
        }



        public IList<ClientEntity> GetClientsByUsernames(string[] names)
        {
            IList<ClientEntity> clients = clientDao.GetClientsByUsernames(names);
            this.CleanUserInfo(clients);
            return clients;
        }

        public IList<ClientEntity> GetClientsByCatalogName(string catalog)
        {
            IList<ClientEntity> clients = clientDao.GetClientsByCatalogName(catalog);
            this.CleanUserInfo(clients);
            return clients;
        }

        private void CleanUserInfo(IList<ClientEntity> clients)
        {
            foreach (var client in clients)
            {
                client.CleanUserInfo();
            }
        }

    }
}