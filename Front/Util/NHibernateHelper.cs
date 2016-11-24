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
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory sessionFactory;
        private const string HibernateCfgXmlFileName = "/hibernate.cfg.xml";

        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + HibernateCfgXmlFileName).BuildSessionFactory();
        }

        public static ISessionFactory getSessionFactory()
        {
            return sessionFactory;
        }
        public static void closeSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }

        public static ISession getSession()
        {
            return sessionFactory.OpenSession();
        }

        public static ISession getHttpSession()
        {
            HttpContext context = HttpContext.Current;
            ISession session = context.Items[CurrentSessionKey] as ISession;
            if (session == null)
            {
                session = sessionFactory.OpenSession();
                context.Items.Add(CurrentSessionKey, session);
            }
            return session;
        }

        public static ISession getAppSession()
        {
            return sessionFactory.OpenSession();
        }


        public static void closeHttpSession()
        {
            HttpContext context = HttpContext.Current;
            ISession session = context.Items[CurrentSessionKey] as ISession;
            if (session == null)
            {
                return;
            }
            session.Close();
            context.Items.Remove(CurrentSessionKey);
        }

       
    }
}