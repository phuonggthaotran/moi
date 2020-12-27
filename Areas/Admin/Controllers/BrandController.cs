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
    public class BrandController : Controller
    {
        BrandBUS brandBUS = new BrandBUS();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View("Index");
        }
      
        public ActionResult Them()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getThuongHieu()
        {
            List<Brand> ldt = brandBUS.getAll();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult getThuongHieubyid(int id)
        //{
        //    List<ListCatg> ldt = brandBUS.getAllbyid(id);
        //    return Json(ldt, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public JsonResult timtenTH(string name)
        {
            List<Brand> ldt = brandBUS.timthuonghieu(name);
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            string st = brandBUS.XoaThuongHieu(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Brand sp)
        {
            string st = brandBUS.SuaThuongHieu(sp);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Insert(Brand ps)
        {
            string st = brandBUS.ThemThuongHieu(ps);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Upload(string name)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/Assets/client/Uploads/" + name + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                l.Add(pf.FileName);
            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}