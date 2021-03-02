﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameFacto.TestProject.WebAPI.Context
{
    public class TestProjectContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Serkan-Ekinci;Database=GameFacto_TestProject; Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
