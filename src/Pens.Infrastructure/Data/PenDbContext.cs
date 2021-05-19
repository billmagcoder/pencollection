using System;
using Microsoft.EntityFrameworkCore;
using Pens.Core.Models;

namespace Pens.Infrastructure.Data
{
    public class PenDbContext : DbContext
    {
        public DbSet<Pen> Pens { get; set; }

        public PenDbContext(DbContextOptions<PenDbContext> options) : base(options)
        {
            
        }

    }
}
