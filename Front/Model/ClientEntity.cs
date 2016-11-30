using Front.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class ClientEntity:Entity
    {
        public ClientEntity()
        {

        }      
        


        public virtual string Username { get; set;  }

        public virtual string Password { get; set; }

       
        public virtual string Salt { get; set; }

        public virtual string RealName { get; set; }

        public virtual RoleEntity Role { get; set; }

        public virtual DepartmentEntity Department { get; set; }

        public virtual IList<CatalogEntity> Catalogs { get; set; }

        

        public void encryptPassword()
        {
            if (Salt == null || Salt.Length == 0)
            {
                Salt = EncryptDecryptHelper.getSalt();
            }
            Password = EncryptDecryptHelper.encryptString(Password + Salt);
        }


        public override string ToString()
        {
            //return Id +"#username:" +Username +"#password:"+ Password + "#salt:"+ Salt +"#realname:"+ RealName+"#role" + Role + "#department:"+Department;
            return "#username:" + Username;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            ClientEntity client = obj as ClientEntity;
            if (client != null && client.Username.Equals(Username))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }


        public Boolean validClient()
        {
            //if (EncryptDecryptHelper.encryptString("123456", Salt).Equals(Password))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            //return EncryptDecryptHelper.encryptString("123456", Salt).Equals(Password);
            return true;
        }


        public void CleanUserInfo()
        {
            Password = null;
            Salt = null;
        }
        
    }
}