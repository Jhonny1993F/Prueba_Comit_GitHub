using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba_Comit_GitHub.Models;

namespace Prueba_Comit_GitHub.Data
{
    public class Prueba_Comit_GitHubContext : DbContext
    {
        public Prueba_Comit_GitHubContext (DbContextOptions<Prueba_Comit_GitHubContext> options)
            : base(options)
        {
        }

        public DbSet<Prueba_Comit_GitHub.Models.Comit> Comit { get; set; } = default!;
    }
}
