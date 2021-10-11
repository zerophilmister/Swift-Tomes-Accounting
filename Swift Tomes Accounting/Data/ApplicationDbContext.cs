﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Swift_Tomes_Accounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swift_Tomes_Accounting.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDB>().HasKey(a => new { a.AccountNumber, a.AccountName });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AccountDB> Account { get; set; }
        public DbSet<EventUser> EventUser { get; set; }
        public DbSet<EventAccount> EventAccount { get; set; }

    }
}
