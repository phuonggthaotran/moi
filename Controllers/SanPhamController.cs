using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        #region Gọi view
        public ActionResult spduoi20()
        {
            return View();
        }

        public ActionResult sptu20den50()
        {
            return View();
        }

        public ActionResult sptren50()
        {
            return View();
        }
        public ActionResult TV4k()
        {
            return View();
        }
        public ActionResult TV8k()
        {
            return View();
        }
        public ActionResult TVQled()
        {
            return View();
        }
        public ActionResult tvduoi55inch()
        {
            return View();
        }
        public ActionResult tvtren55inch()
        {
            return View();
        }
        #endregion

        ProductBUS dtb = new ProductBUS();
        [HttpGet]
        
        public JsonResult getSP()
        {
           
            List<Product> ldt = dtb.LayAllSP();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        #region Sản phẩm theo giá
        public JsonResult duoi20tr()
        {

            List<Product> ldt = dtb.duoi20();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult tu20den50()
        {

            List<Product> ldt = dtb.tu20den50();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult tren50()
        {

            List<Product> ldt = dtb.tren50();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Sản phẩm theo loại
        public JsonResult Tivi4k()
        {

            List<Product> ldt = dtb.tivi4k();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult tivi8K()
        {

            List<Product> ldt = dtb.tivi8k();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TiviQled()
        {

            List<Product> ldt = dtb.Qled();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Sản phẩm theo kích thước màn hình
        public JsonResult Duoi55inch()
        {

            List<Product> ldt = dtb.Duoi55inch();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Tren55inch()
        {

            List<Product> ldt = dtb.tren55inch();
            return Json(ldt, JsonRequestBehavior.AllowGet);
        }
        #endregion
        [HttpPost]
        public JsonResult timSP(string name)
        {
            if (name == "")
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Product> ldt = dtb.timSP(name);
                return Json(ldt, JsonRequestBehavior.AllowGet);
            }
        }
       
        public ActionResult SPDetail(int id)
        {
            Session.Add("id", id);
            return View();
        }
            public JsonResult chitiet()
        {
            Product lsp = dtb.lay1sp(Convert.ToInt32(Session["id"].ToString()));
            //List<SanPham> lsp = spbus.LaySP("Lẩu")
            return Json(lsp, JsonRequestBehavior.AllowGet);
            ////lay ve 1sp
            //var ds = dtb.lay1sp(id);
            ////loai bo san pham ma minh da hien thi
            //return Json(ds, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getSPLienquan(int id)
        {
            var lq = dtb.getSPLQ(id);
            return Json(lq, JsonRequestBehavior.AllowGet);
        }
    }
}