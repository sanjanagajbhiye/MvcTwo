using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTwo.Data;

namespace MvcTwo.Models
{
    public class RegModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Team { get; set; }
        public int Age { get; set; }

        public string SaveReg(RegModel model)
        {
            string message = "Reg is successfull";
            MvcTwoEntities db = new MvcTwoEntities();
            var savereg = new tblReg()
            {
                Name = model.Name,
                Mail = model.Mail,
                Team = model.Team,
                Age = model.Age,
            };
            db.tblRegs.Add(savereg);
            db.SaveChanges();
            return message;
        }
    }
}