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
            //initAdminClient();

        }

        public void initAdminClient()
        {
            Client client = new Client();
            client.Username = "admin";
            client.Password = "123456";
            client.RealName = "yangtf";
            client.Role = "superadmin";
            client.Department = "K6";
            client.encryptPassword();
            ClientDao dao = new ClientDao();
            dao.save(client);
        }

        private void initRoles()
        {
            Role[] roles = createRoles();
            RoleDao dao = new RoleDao();
            dao.save(roles);
        }

        private Role[] createRoles()
        {
            Role[] roles = new Role[3];
            roles[0] = new Role("superadmin", "超级管理员"); // 只有一个
            roles[1] = new Role("admin", "管理员");// 每个科室的管理员
            roles[2] = new Role("client", "用户");// 普通用户，发帖
            return roles;

        }
    }
}
