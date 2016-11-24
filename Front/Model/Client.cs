using Front.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class Client
    {
        public Client()
        {

        }

        public virtual string Id { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

       
        public virtual string Salt { get; set; }

        public virtual string RealName { get; set; }

        public virtual string Role { get; set; }

        public virtual string Department { get; set; }

        

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
            return Id +"#username:" +Username +"#password:"+ Password + "#salt:"+ Salt +"#realname:"+ RealName+"#role" + Role + "#department:"+Department;

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
            return EncryptDecryptHelper.encryptString("123456", Salt).Equals(Password);
        }
        
    }
}