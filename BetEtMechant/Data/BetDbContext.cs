using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetEtMechant.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetEtMechant.Data
{
    public class BetDbContext : IdentityDbContext<User>
    {

        public BetDbContext(DbContextOptions<BetDbContext> options) :  base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Championship> Championships { get; set; }

    }
}
