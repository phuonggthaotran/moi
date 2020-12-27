using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.DataAccess;
using DA3Last.Models;

namespace DA3Last.Bussiness
{
    public class QLUserBus
    {
        UserDAL usDAL = new UserDAL();
        public List<Users> LayAllUser()
        {
            return usDAL.GetAllUser();
        }
    }
}