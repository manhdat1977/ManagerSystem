using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSystem
{
    public class EncryptionPass
    {
        public string mahoa(string pass)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "SHA1");
        }

    }
}