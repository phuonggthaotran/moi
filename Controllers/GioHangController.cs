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
        public ActionResult ThanhToan()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddCart(Product s)
        {
            if (Session["giohang"] == null)//Neu gio hang chua duoc khoi tao
            {
                Session["giohang"] = new List<GioHang>();//khoi tao session gan vao danh sach ct don hang
            }
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            GioHang d = null;
            if (giohang.Find(m => m.product_name == s.product_name) == null)//kiem tar xem san pham da co trong gio hang chua
            {
                d = new GioHang();
                d.product_name = s.product_name;
                d.price = Convert.ToInt32(s.price);
                d.image = s.image;
               
                giohang.Add(d);//them
            }

            return Json(new { ctdon = d }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCarts()
        {
            List<GioHang> ds = new List<GioHang>();
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<GioHang>();
            }
            else
            {
                ds = Session["giohang"] as List<GioHang>;
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