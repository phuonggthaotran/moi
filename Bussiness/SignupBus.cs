using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.Models;
using DA3Last.DataAccess;

namespace DA3Last.Bussiness
{
    public class SignupBus
    {
        UserDAL usDAL = new UserDAL();
        public string DangKy(Users us)
        {
            return usDAL.SignUp(us);
        }
    }
}