using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
    }
}
