using Front.Dao;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Service
{
    public class RoleService
    {
        private RoleDao roleDao;
       

        public RoleService()
        {
            roleDao = new RoleDao();
           
        }

        public IList<RoleEntity> GetAllRoles()
        {
            return roleDao.getAllRoles();
        }

        public RoleEntity GetRoleByName(string name)
        {
            return roleDao.getByName(name);
        }
    }
}