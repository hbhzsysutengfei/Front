using Front.Model;
using Front.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Dao
{
    public class RoleDao:DataDao
    {
        public RoleDao()
        {

        }

        public void save(RoleEntity role)
        {           
            ITransaction tx = session.BeginTransaction();            
            session.Save(role);
            tx.Commit();
            session.Close();
        }

        public void save(RoleEntity[] roles)
        {
            ITransaction tx = session.BeginTransaction();
            foreach (var role in roles)
            {
                session.Save(role);
            }         
            tx.Commit();
            session.Close();
        }


        public IList<RoleEntity> getAllRoles()
        {
            IList<RoleEntity> roles = session.QueryOver<RoleEntity>().Take(10).List();
            session.Close();
            return roles;
        }

        public RoleEntity getByName(String name)
        {
            RoleEntity role = session.QueryOver<RoleEntity>().Where(r => r.RoleName == name).SingleOrDefault();
            session.Close();
            return role;

        }
    }
}