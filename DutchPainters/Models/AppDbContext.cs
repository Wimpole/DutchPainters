using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchPainters.Models;

namespace DutchPainters.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<DutchPainters.Models.Painter> Painter { get; set; }
        public DbSet<DutchPainters.Models.Painting> Painting { get; set; }
    }
}
