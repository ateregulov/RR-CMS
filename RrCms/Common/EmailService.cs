using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace RrCms.Common
{
    public class EmailService
    {
        /// <summary>
        /// Простенький метод отправки через SMTP сервер GMail
        /// </summary>
        /// <param name="message"></param>
        public void SendByGoogle(MailMessage message)
        {
            if (message != null)
            {

                var mailclient = new SmtpClient();
                mailclient.Host = "smtp.gmail.com";
                mailclient.Port = 587;

                mailclient.EnableSsl = true;

                //TODO: Хардкодим здесь либо берем из БД настройки 
                mailclient.Credentials = new System.Net.NetworkCredential(
                                                 "login",
                                                 "password");
                mailclient.Send(message);
            }
        }
    }

}