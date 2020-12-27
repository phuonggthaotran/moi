using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.DataAccess;
using DA3Last.Models;

namespace DA3Last.Bussiness
{
    public class LoginBus
    {
        UserDAL ul = new UserDAL();

        public Users checkUser(string name, string pass)
        {
            return ul.CheckAccount(name, pass);
        }
    }
}