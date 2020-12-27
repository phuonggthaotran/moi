﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA3Last.Bussiness;
using DA3Last.Models;

namespace DA3Last.Areas.Admin.Controllers
{
    public class SignupController : Controller
    {
        SignupBus signupBus = new SignupBus();
        // GET: Admin/Signup
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public JsonResult Signup(Users us)
        {
            string res = signupBus.DangKy(us);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}