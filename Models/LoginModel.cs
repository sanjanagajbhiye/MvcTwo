using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTwo.Data;

namespace MvcTwo.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Contact { get; set; }

        public string SaveLogin(LoginModel model)
        {
            string message = "REGISTERED Successfully!!";
            MvcTwoEntities db = new MvcTwoEntities();
            var savelog = new tblLogin()
            {
                Name = model.Name,
                Contact = model.Contact,
            };
            db.tblLogins.Add(savelog);
            db.SaveChanges();
            return message;
        }

        public List<LoginModel> GetLoginList()
        {
            MvcTwoEntities db = new MvcTwoEntities();
            List<LoginModel> LogList = new List<LoginModel>();
            var MvcLog = db.tblLogins.ToList();
            if (MvcLog != null)
            {
                foreach (var log in MvcLog)
                {
                    LogList.Add(new LoginModel()
                    {
                        Id = log.Id,
                        Name = log.Name,
                        Contact = log.Contact,
                    });
                }
            }
            return LogList;
        }

        public string DltLogin(int id)
        {
            string message = "";
            MvcTwoEntities db = new MvcTwoEntities();
            var Dlt_Log = db.tblLogins.Where(p => p.Id == id).FirstOrDefault();
            if (Dlt_Log != null)
            {
                db.tblLogins.Remove(Dlt_Log);
            }
            db.SaveChanges();
            message = "data deleted successfully";
            return message;
        }
    }
}