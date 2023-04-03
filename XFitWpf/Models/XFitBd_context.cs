using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFitWpf.Models
{
    public class XFitBd_context : DbContext
    {
        public XFitBd_context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MIV\\SQLEXPRESS;Database=SPORT;Trusted_Connection=True;");
        }

        public DbSet<Trainer> Trainers { get; set; } = null!;
        public DbSet<Section> Sections { get; set; } = null!;
        public DbSet<SeasonTicket> SeasonTickets { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Amount> Amounts { get; set; } = null!;
    }
}
