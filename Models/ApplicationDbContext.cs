﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRYBZ_CCSB.Models.ViewModels;
using CRYBZ_CCSB.Models;

namespace CRYBZ_CCSB.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CRYBZ_CCSB.Models.Contract> Contract { get; set; }
    }
}
