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


        //public  void BatchSave<T>(List<T>[] records)
        //{
        //    IStatelessSession session = NHibernateHelper.getStatelessSession();
        //    ITransaction tx = session.BeginTransaction();
            
        //    tx.Commit();
        //    session.Close();
        //}

      

    }
}