using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Controllers
{
    public class HomeController : Controller
    {
        BrandBUS br = new BrandBUS();
        CategoriesBUS cateb = new CategoriesBUS();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult ChinhSachThanhToan()
        {
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult HuongDanMuaHang()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getThuongHieu()
        {
        
            var lldt = br.getAll();
            return Json(lldt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getloaitheoten(string name)
        {
            var loai = cateb.layLoai(name);
            return Json(loai, JsonRequestBehavior.AllowGet);
        }
        
    }
}