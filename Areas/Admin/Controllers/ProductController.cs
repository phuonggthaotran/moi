using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Models;
using DA3Last.Bussiness;
using System.IO;

namespace DA3Last.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductBUS productBUS = new ProductBUS();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View("Index");
        }
       
       
        public ActionResult Them()
        {
            return View();
        }
        
        
        [HttpGet]
        public JsonResult getSP()
        {
            List<Product> ldt = productBUS.LayAllSP();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult timSP(string name)
        {
            List<Product> ldt = productBUS.timSP(name);
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            string st = productBUS.XoaSP(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Product sp)
        {
            string st = productBUS.SuaSP(sp);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Insert(Product ps)
        {
            string st = productBUS.ThemSP(ps);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Upload(string name)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/Assets/client/image" + name + "/");
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