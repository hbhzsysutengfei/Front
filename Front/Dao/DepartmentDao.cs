using Front.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Dao
{
    public class DepartmentDao:DataDao
    {
        public DepartmentDao()
        {

        }

        public string save(DepartmentEntity department)
        {
            ITransaction tx = session.BeginTransaction();
            string generatedId = session.Save(department) as string;
            tx.Commit();
            return generatedId;
        }

        public DepartmentEntity getByName(string name)
        {
            DepartmentEntity department = session.QueryOver<DepartmentEntity>().Where(m => m.DepartmentName == name).SingleOrDefault();
            //session.Close();
            return department;
        }

        public void save(DepartmentEntity[] departments)
        {
            ITransaction tx = session.BeginTransaction();
            foreach (var department in departments)
            {
                session.Save(department);
            }
            tx.Commit();
            //session.Close();
        }

        public IList<DepartmentEntity> getAllDepartments()
        {
            return session.QueryOver<DepartmentEntity>().OrderBy(m=>m.UpdateTime).Asc.List();
        }

        internal DepartmentEntity getByDesc(string desc)
        {
            return session.QueryOver<DepartmentEntity>().Where(m => m.Description == desc).SingleOrDefault();
        }
    }
}