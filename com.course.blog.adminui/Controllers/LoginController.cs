using com.course.blog.adminui.Helpers;
using com.course.blog.entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace com.course.blog.adminui.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbBlog _context;
        public LoginController(DbBlog context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.Get<bool>("NotAuthorized"))
            {
                HttpContext.Session.Set<bool>("NotAuthorized", false);
                TempData["NotAuthorized"] = true;
            }

            return View();
        }

        [HttpPost]
        public JsonResult CreateSession(string userName, string password)
        {
            var encryptedPassword = password.CreateMD5();

            if (_context.Users.Any(a => a.UserName == userName && a.Password == encryptedPassword))
            {
                var user = _context.Users.First(u => u.UserName == userName && u.Password == encryptedPassword);

                HttpContext.Session.Set<User>("User", user);

                return Json(new { status = true, url = "/Admin/Index" });
            }
            else
            {
                return Json(new { status = false });
            }
        }

        [HttpPost]
        public JsonResult SendPassword(string eMail)
        {
            if (_context.Users.Any(u => u.UserName == eMail))
            {
                SendMail(eMail);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        private void SendMail(string eMail)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("confirmation@sonerkoylu.com");
            mailMessage.To.Add(eMail);


            var message = $"<b>Gönderen :</b> Soner KÖYLÜ<br/><b>sonerkoylu.com :</b> {eMail}<br/><b>Konu: </b> Şifre Hatırlatma<br/><b>Mesaj İçeriği:</b> <br>Şifreniz: 12345678";
            mailMessage.Subject = "Şifre Hatırlatma";
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient("mail.sonerkoylu.com", 587);
            smtpClient.Credentials = new NetworkCredential("confirmation@sonerkoylu.com", "VaNXdB6#cx%y^H");
            smtpClient.Send(mailMessage);
        }
    }
}
