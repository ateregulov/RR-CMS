using System;
using System.Linq;
using System.Net.Mail;
using RrCms.Models;

namespace RrCms.Common
{
    public static class EmailService
    {
        /// <summary>
        /// Простенький метод отправки
        /// </summary>
        /// <param name="message"></param>
        public  static void SendMail(MailMessage message)
        {
            if (message == null) return;
            using (var db = new AdminParamEntities())
            {
                var mailclient = new SmtpClient
                                     {
                                         Host = db.AdminParams.First(p => p.Name == "smtpserver").Value,
                                         Port = Convert.ToInt32(db.AdminParams.First(p => p.Name == "smtpport").Value),
                                         EnableSsl = Convert.ToBoolean(db.AdminParams.First(p => p.Name == "smtpssl").Value),
                                         Credentials = new System.Net.NetworkCredential(
                                             db.AdminParams.First(p => p.Name == "smtplogin").Value,
                                             db.AdminParams.First(p => p.Name == "smtppass").Value)
                                     };


                mailclient.Send(message);
            }
        }
    }

}