using Front.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Dao
{
    public class DataDao
    {
        protected ISession session;
        protected static readonly int FETCH_MAX_COUNT;

        static DataDao()
        {
            FETCH_MAX_COUNT = 10;
        }

        public DataDao()
        {
            session = NHibernateHelper.getSession();
        }

        public DataDao(ISession session)
        {
            this.session = session;
        }

        public void closeDaoSession()
        {
            if (session != null)
            {
                session.Close();
            }
        }


        

      

    }
}