using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TitsBot.Models.TitsModels;

namespace TitsBot.Models
{
    class ApplicationContext : DbContext
    {
        public DbSet<TitsModel> Tits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=titsBotDb;Trusted_Connection=True;");
        }
    }
}
