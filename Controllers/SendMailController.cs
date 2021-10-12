using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;
using System;
using FluentEmail.Smtp;
using FluentEmail.Core;

/* Hier worden de emails verzonden naar de user. */
namespace CRYBZ_CCSB
{
    public class SendEmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SendMail(string emailtxt)
        {
            // emailtxt is de email van de ontvanger
            ViewBag.email = emailtxt;
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("beheerdervanccsb@gmail.com", "Ronaniseendikkepadvis04!"),
                EnableSsl = true,
            });
            Email.DefaultSender = sender;
            //html template
            string filename = $"{Directory.GetCurrentDirectory()}/Tamplates/index.html";
            if (!String.IsNullOrEmpty(emailtxt))

            {

                var email = Email
                //hier komen de gegevens van email (Onderwerp text etc)
                .From("beheerdervanccsb@gmail.com", "X")
                .To(emailtxt, "Naam verzender")
                .Subject("Onderwerp Email")
                .UsingTemplateFromFile(filename, new { Name = "test" });
                var response = await email.SendAsync();
                return View("../SendEmail/Index");
            }

            else
            {
                return View("../SendEmail/Index");
            }
        }
    }
}