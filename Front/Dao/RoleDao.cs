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
        public void save(Role role)
        {
            session = NHibernateHelper.getSession();
            ITransaction tx = session.BeginTransaction();            
            session.Save(role);
            tx.Commit();
            session.Close();
        }

        public void save(Role[] roles)
        {
            session = NHibernateHelper.getSession();
            ITransaction tx = session.BeginTransaction();
            foreach (var role in roles)
            {
                session.Save(role);
            }         
            tx.Commit();
            session.Close();
        }


        public IList<Role> getAllRoles()
        {
            session = NHibernateHelper.getSession();
            //session.BeginTransaction();
            IList<Role> roles = session.QueryOver<Role>().Take(10).List();
            session.Close();
            return roles;
        }
    }
}