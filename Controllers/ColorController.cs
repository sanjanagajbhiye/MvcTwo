using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTwo.Models;

namespace MvcTwo.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveColor(ColorModel model)
        {
            try
            {
                return Json(new { message = (new ColorModel().SaveColor(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Savesms(ColorModel model)
        {
            try
            {
                return Json(new { model = new ColorModel().Savesms(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        

        public ActionResult GetColorList()
        {
            try
            {
                return Json(new {  model= (new ColorModel().GetColorList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message });
            }
        }

        public ActionResult DltColor(int id)
        {
            try
            {
                return Json(new { model = (new ColorModel().DltColor(id)) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetEditData(int id)
        {
            try
            {
                return Json(new { model = (new ColorModel().GetEditData(id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }




    }
}