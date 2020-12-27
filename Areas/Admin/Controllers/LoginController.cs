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
            LoginBus lb = new LoginBus();
            Users u = lb.checkUser(us, pw);
            if (u == null) //Tài khoản không đúng
            {
                return Json(u, JsonRequestBehavior.AllowGet);
            }
            else  //Tài khoản đúng
            {
                //Session.Add("User_Session", u);
                FormsAuthentication.SetAuthCookie(us, false);
                return Json(u, JsonRequestBehavior.AllowGet);
                // return RedirectToAction("index", "Home");
            }
        }
    }
}