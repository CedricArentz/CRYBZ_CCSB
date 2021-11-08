using CRYBZ_CCSB.DatabaseInitializer;
using CRYBZ_CCSB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRYBZ_CCSB.DatabaseInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            if (_db.Users.Any())
            {
                return;
            }
            else
            {
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "SophiavanGriekenland@ccsb.com",
                    Email = "SophiavanGriekenland@ccsb.com",
                    EmailConfirmed = true,
                    FirstName = "Sophia",
                    MiddleName = "van",
                    LastName = "Griekenland"
                }, "Test123!").GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "CarlovanderStal@ccsb.com",
                    Email = "CarlovanderStal@ccsb.com",
                    EmailConfirmed = true,
                    FirstName = "Carlo",
                    MiddleName = "van der",
                    LastName = "Stal"
                }, "Test123!").GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Cedric.arentz@gmail.com",
                    Email = "Cedric.arentz@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Cedric",
                    LastName = "Arentz"
                }, "Test123!").GetAwaiter().GetResult();
            }
        }
    }
}