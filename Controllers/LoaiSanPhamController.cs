using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        CategoriesBUS categoriesBUS = new CategoriesBUS();
        // GET: LoaiSanPham
        public ActionResult Index()
        {
            return View();
        }
        //public JsonResult getLoaiSP(string name)
        //{

        //    List<Category> ldt = categoriesBUS.layLoai(name);
        //    return Json(ldt, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult getAllLoaiSP()
        {
            List<Category> list = categoriesBUS.getAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}