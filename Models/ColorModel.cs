using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTwo.Data;
using System.Text;
using System.IO;
using System.Net;

namespace MvcTwo.Models
{
    public class ColorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Color { get; set; }

        public string MobileNo { get; set; }

        public string SaveColor(ColorModel model)
        {
            string message = "Colored successfully";
            MvcTwoEntities db = new MvcTwoEntities();
            var getData = db.tblColors.Where(p => p.Id== model.Id).FirstOrDefault();
            if (getData == null)
            { 
              var saveColor = new tblColor()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Mail = model.Mail,
                    Color = model.Color
                };
                db.tblColors.Add(saveColor);
                db.SaveChanges();
                message = "Added Suucessfully";
                return message;
            }
            else
            {
                getData.Name = model.Name;
                getData.Mail = model.Mail;
                getData.Color = model.Color;
            };

            db.SaveChanges();
            message = "Save Successfully";
            return message;
        }

        public string Savesms(ColorModel model)
        {
            string msg = "";
            MvcTwoEntities db = new MvcTwoEntities();
            var Savesms = new tblColor()
            {
                Name = model.Name,
                Mail =model.Mail,
                Color = model.Color,
                MobileNo = model.MobileNo
                
            };
            db.tblColors.Add(Savesms);
            db.SaveChanges();
            string Contact = model.MobileNo;
            string sAPIKey = "fYMsEmpZQUewatTPf0TktQ";
            string sNumber = Contact;
            string sMessage = "Hi " + model.Name +  "  Paid Successfully ";
            string sSenderId = "BSCAKE";
            string sChannel = "trans";
            string sRoute = "8";
            string sURL = "http://mysms.msg24.in/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderId + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "&route=" + sRoute + "";

            string sResponse = GetResponse(sURL);
            return msg = model.Name;

        }
        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public List<ColorModel> GetColorList()
        {
            MvcTwoEntities db = new MvcTwoEntities();
            List<ColorModel> ColorList = new List<ColorModel>();
            var MvcColor = db.tblColors.ToList();
            if (MvcColor != null)
            {
                foreach (var List in MvcColor)
                {
                    ColorList.Add(new ColorModel()
                    {
                        Id = List.Id,
                        Name = List.Name,
                        Mail = List.Mail,
                        Color = List.Color

                    });
                }
            }
            return ColorList;
        }

        public string DltColor(int id)
        {
            string message = "";
            MvcTwoEntities db = new MvcTwoEntities(); 
            var Dlt_Color = db.tblColors.Where(p => p.Id == id).FirstOrDefault();
            if(Dlt_Color != null)
            {
                db.tblColors.Remove(Dlt_Color);
            };
            db.SaveChanges();
            message = "Record Deleted Successfully";
            return message;
        }

        public ColorModel GetEditData(int id)
        {
            string message = "";
            ColorModel model = new ColorModel();
            MvcTwoEntities db = new MvcTwoEntities();
            var editData = db.tblColors.Where(p => p.Id == id).FirstOrDefault();
            if(editData != null)
            {
                model.Id = editData.Id;
                model.Name = editData.Name;
                model.Mail = editData.Mail;
                model.Color = editData.Color;
            }
            message = "Record edited successfully";
            return model;
        }
    }
}