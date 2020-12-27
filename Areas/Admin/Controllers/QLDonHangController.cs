using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Areas.Admin.Controllers
{
    public class QLDonHangController : Controller
    {
        DonHangBUS dhb = new DonHangBUS();
        // GET: Admin/QLDonHang
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetDonHang()
        {
            List<Donhang> ldh = dhb.getdonhang();
            return Json(ldh, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult xoadonhang(int id)
        {
            string st = dhb.xoadonhang(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult suadonhang(Donhang sp)
        {
            string st = dhb.suadonhang(sp);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getngaydat(string ngay, string thang, string nam)
        {
            List<Donhang> ldh = dhb.getngaydat(ngay, thang, nam);
            return Json(ldh, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult gettrangthai(string trangthai)
        {
            List<Donhang> ldh = dhb.gettrangthai(trangthai);
            return Json(ldh, JsonRequestBehavior.AllowGet);
        }
    }
}