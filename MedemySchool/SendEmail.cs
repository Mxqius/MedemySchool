using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net;

namespace MedemySchool
{
    public class SendEmail
    {
        public bool SendEmailTo(string ToEmail, string Title, string MessageBody)
        {
            try
            {
                // Using System.Net
                // Using System.Net.Mail
                // Using System.Net.NetworkInformation
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //نام فرستنده
                mail.From = new MailAddress("mxqius@gmail.com");
                //آدرس گیرنده یا گیرندگان
                mail.To.Add(ToEmail);
                //عنوان ایمیل
                mail.Subject = Title;
                //بدنه ایمیل
                mail.Body = MessageBody;
                mail.IsBodyHtml = true;
                //   mail.Priority = MailPriority.High;
                //مشخص کرن پورت 
                SmtpServer.Port = 587;
                //username : به جای این کلمه نام کاربری ایمیل خود را قرار دهید
                //password : به جای این کلمه رمز عبور ایمیل خود را قرار دهید
                SmtpServer.Credentials = new NetworkCredential("mxqius@gmail.com", "Mxqius@A2sh!kan&hired");
                SmtpServer.EnableSsl = true;
                // SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
