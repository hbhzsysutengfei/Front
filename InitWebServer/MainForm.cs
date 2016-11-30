using Front;
using Front.Dao;
using Front.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitWebServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            //initRoles();
            //initDepartment();

            initCatalog();

            initAdminClient();

        }

        private void initCatalog()
        {
            string[] catalogNames = { "调研文章","审批","申请"};
            CatalogEntity[] catalogs = new CatalogEntity[3];
            for (int index = 0; index < catalogNames.Length; index++)
            {
                catalogs[index] = new CatalogEntity(catalogNames[index]);                
            }
            CatalogDao dao = new CatalogDao();
            dao.save(catalogs);
            

        }

        private void initRoles()
        {
            RoleEntity[] roles = createRoles();
            RoleDao dao = new RoleDao();
            dao.save(roles);
        }

        public void initDepartment()
        {
            string[] departmentNames = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18" };
            string[] departmentDescriptions = { "一科", "二科", "三科", "四科", "五科", "六科", "七科", "八科", "九科", "十科",                                
                                                  "十一科", "十二科", "十三科" , "十四科", "十五科","秘书科", "政工科", "行政科"};
            DepartmentEntity[] departments = new DepartmentEntity[18];
            for (int index = 0; index < departmentNames.Length; index++)
            {
                departments[index] = new DepartmentEntity(departmentNames[index], departmentDescriptions[index]);
            }

            DepartmentDao dao = new DepartmentDao();
            dao.save(departments);
        }

        public void initAdminClient()
        {
            ClientEntity client = new ClientEntity();
            RoleDao roleDao = new RoleDao();
            DepartmentDao departmentDao = new DepartmentDao();
            client.Username = "admin";
            client.Password = "123456";
            client.RealName = "yangtf";

            client.Role = roleDao.getByName("superadmin");
            client.Department = departmentDao.getByName("6");
            client.encryptPassword();

            IList<CatalogEntity> catalogs = new CatalogDao().getAll();
            client.Catalogs = catalogs;

            ClientDao dao = new ClientDao();
            dao.save(client);
        }

       

        private RoleEntity[] createRoles()
        {
            RoleEntity[] roles = new RoleEntity[3];
            roles[0] = new RoleEntity("superadmin", "超级管理员"); // 只有一个
            roles[1] = new RoleEntity("admin", "管理员");// 每个科室的管理员
            roles[2] = new RoleEntity("client", "用户");// 普通用户，发帖
            return roles;
        }

    }
}
