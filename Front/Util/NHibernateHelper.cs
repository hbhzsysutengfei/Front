using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Util
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory sessionFactory;

        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession getSession()
        {
            return sessionFactory.OpenSession();
        }

       
    }
}