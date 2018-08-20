using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTradingClub.Models
{
    public class BTCContext : IdentityDbContext<User>
    {
        #region Public Properties

        public DbSet<Book> Books { get; set; }
        public DbSet<Trade> Trades { get; set; }

        #endregion

        #region Constructor
        public BTCContext(DbContextOptions<BTCContext> options) : base(options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
