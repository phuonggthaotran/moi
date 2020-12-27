using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        SupplierBUS supplierBUS = new SupplierBUS();
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View("Index");
        }
       
       
        public ActionResult Them()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getNCC()
        {
            List<Supplier> ldt = supplierBUS.getAll();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult timNCC(string name)
        {
            List<Supplier> ldt = supplierBUS.timNCC(name);
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            string st = supplierBUS.XoaNCC(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Supplier sp)
        {
            string st = supplierBUS.SuaNCC(sp);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Insert(Supplier ps)
        {
            string st = supplierBUS.ThemNCC(ps);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
    }
}