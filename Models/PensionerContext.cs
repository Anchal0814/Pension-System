using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPension.Models
{
    public class PensionerContext : DbContext
    {
        public PensionerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Login> Login { get; set; }
        public DbSet<Pensioner> Pensioner { get; set; }
    }
}
