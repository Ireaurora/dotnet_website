using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mywebsite.Models;
using System.Net;
using System.Net.Mail;


namespace mywebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static MailMessage GetMessage()
        {
            return new MailMessage();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Privacy(ContactFormModel model)
        {
            try
            {
                var body = "<p>Email From: {0} {1}({3})</p><p>Message:</p><p>{2}</p>";
                using (MailMessage message = GetMessage())
                {
                    message.To.Add(new MailAddress("irenesarigu.wp@gmail.com"));  // recepient
                    message.From = new MailAddress("irenesarigu.wp@gmail.com");  // sender
                    message.Subject = "Your email subject";
                    message.Body = string.Format(body, model.FirstName, model.LastName, model.Email, model.Feedback);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "irenesarigu.wp@gmail.com",  // test@gmail.com
                            Password = "girasole"  // password of your gmail account
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                        return RedirectToAction("Sent");
                    }
                }
            }
            catch {
                return View();
            }
        }


        public ActionResult Sent()
        {
            return View();
        }

    }
}
