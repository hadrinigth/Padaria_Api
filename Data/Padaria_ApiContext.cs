using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Padaria_Api.Models;

namespace Padaria_Api.Data
{
    public class Padaria_ApiContext : DbContext
    {
        public Padaria_ApiContext (DbContextOptions<Padaria_ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Padaria_Api.Models.Deposito> Deposito { get; set; } = default!;
        public DbSet<Padaria_Api.Models.Produtos> Produtos { get; set; } = default!;
    }
}
