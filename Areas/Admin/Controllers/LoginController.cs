using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Users u = new Users();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public JsonResult Logout()
        {
            //Session.Remove("User_Session");
            FormsAuthentication.SignOut();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DangNhap(string us, string pw)
        {
            LoginBus dnb = new LoginBus();
            Users dn = dnb.checkUser(us, pw);
            if (dn == null || dn.Role != "Admin" && dn.Role != "KhachHang")
            {
                return Json(dn, JsonRequestBehavior.AllowGet);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(us, false);
                return Json(dn, JsonRequestBehavior.AllowGet);
            }
        }
    }
}