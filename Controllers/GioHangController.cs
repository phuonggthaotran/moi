﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Controllers
{
    public class GioHangController : Controller
    {
        DonHangBUS dhb = new DonHangBUS();
        // GET: GioHang
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public JsonResult AddCart(Product s)
        {
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<CTDonHang>();
            }
            List<CTDonHang> giohang = Session["giohang"] as List<CTDonHang>;
            CTDonHang d = null;
            if (giohang.Find(m => m.product_name == s.product_name) == null)
            {
                d = new CTDonHang();
                d.product_name = s.product_name;
                d.price = Convert.ToInt32(s.price);
                d.image = s.image;
               
                giohang.Add(d);
            }

            return Json(new { ctdon = d }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCarts()
        {
            List<CTDonHang> ds = new List<CTDonHang>();
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<CTDonHang>();
            }
            else
            {
                ds = Session["giohang"] as List<CTDonHang>;
            }
            return Json(new { DSDonHang = ds }, JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        public JsonResult GetDonHang()
        {
            List<Donhang> ldh = dhb.getdonhang();
            return Json(ldh, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult themdonhang(Donhang dt)
        {
            string st = dhb.themdonhang(dt);
            dhb.xoa();
            return Json(st, JsonRequestBehavior.AllowGet);
        }
    }
}