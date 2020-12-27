using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesBUS categoriesBUS = new CategoriesBUS();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getLoai()
        {
            List<Category> ldt = categoriesBUS.getAll();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult timLoai(string name)
        {
            List<Category> ldt = categoriesBUS.timLoai(name);
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            string st = categoriesBUS.XoaLoai(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Category sp)
        {
            string st = categoriesBUS.SuaLoai(sp);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Insert(Category ps)
        {
            string st = categoriesBUS.ThemLoai(ps);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
       
    }
}