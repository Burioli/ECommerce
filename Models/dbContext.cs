using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using burioli.alessandro._5h.ECommerce.Models;

    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<burioli.alessandro._5h.ECommerce.Models.Prevendita> Prevendita { get; set; } = default!;
    }
