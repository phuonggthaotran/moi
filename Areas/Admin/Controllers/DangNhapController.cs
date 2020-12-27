using DA3Last.Bussiness;
using DA3Last.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DA3Last.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Admin/DangNhap
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public JsonResult Login(string us, string pw)
        {
            DangNhapBUS dnb = new DangNhapBUS();
            DangNhap dn = dnb.checkDangNhap(us, pw);
            if (dn == null || dn.chucvu != "Admin" && dn.chucvu != "KhachHang")
            {
                return Json(dn, JsonRequestBehavior.AllowGet);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(us, false);
                return Json(dn, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Logout()
        {
            FormsAuthentication.SignOut();
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}