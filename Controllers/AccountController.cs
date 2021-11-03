using CRYBZ_CCSB.Models;
using CRYBZ_CCSB.Models.ViewModels;
using CRYBZ_CCSB.Utility;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Appointment");
                }
                ModelState.AddModelError("", "Inloggen mislukt");
            }
            return View(model);
        }
        public async Task<IActionResult> Register()
        {
            //Create all roles if role admin does not exist
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Employee));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Customer));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewBag.email = model.emailtxt;
            
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("beheerdervanccsb@gmail.com", "Ronaniseendikkepadvis04!"),
                EnableSsl = true,
            });
            Email.DefaultSender = sender;

            string html = Utility.Helper.EmailBody.Replace("@@FirstName", model.FirstName).Replace("@@Email",model.Email).Replace("@@Password", model.Password);


            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,

            };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                

                if (result.Succeeded)
                {
                    var email = Email
                    //hier komen de gegevens van email (Onderwerp text etc)
                    .From("beheerdervanccsb@gmail.com", "Welkom bij CCSB!")
                    .To(model.Email, "Naam verzender")
                    .Subject("Onderwerp Email")
                    .Body(html, true);
                    var response = await email.SendAsync();

                    // Assign role to user and log the user in and redirect to the homepage
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                //Add all errors to the modelstate
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
