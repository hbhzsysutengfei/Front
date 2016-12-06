using Front.Dao;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Service
{
    public class DepartmentService
    {
        private DepartmentDao dao;
        public DepartmentService()
        {
            dao = new DepartmentDao();
        }

        public IList<DepartmentEntity> getAllDepartments()
        {
            return dao.getAllDepartments();
        }

        public DepartmentEntity getByName(string departmentname)
        {
            return dao.getByName(departmentname);
        }

        public DepartmentEntity getByDesc(string desc)
        {
            return dao.getByDesc(desc);
        }
    }
}