using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Data
{
    public class ReferralRockWebAppContext : DbContext
    {
        public ReferralRockWebAppContext (DbContextOptions<ReferralRockWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ReferralRockWebApp.Models.Member> Member { get; set; } = default!;
    }
}
