using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTwo.Models;

namespace MvcTwo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexLogList()
        {
            return View();
        }


        public ActionResult SaveLogin(LoginModel model)
        {
            try
            {
                return Json(new { message = (new LoginModel().SaveLogin(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetLoginList(LoginModel model)
        {
            try
            {
                return Json(new { model = (new LoginModel().GetLoginList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { model = Ex.Message });
            }
        }

        public ActionResult DltLogin(int id)
        {
            try
            {
                return Json(new { model = (new LoginModel().DltLogin(id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { model = Ex.Message });
            }
        }
    }
}