using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ferma.Models
{
    public class FermaContext : IdentityDbContext<IdentityUser>

    {
        public FermaContext()
        {
        }

        public RestaurantContext(DbContextOptions<FermaContext> options)
            : base(options)
        { }

        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Nota> Note { get; set; }
        public DbSet<Rol> Roluri { get; set; }
        public DbSet<User> Users { get; set; }
        
         public DbSet<DetaliiComanda> DetaliiComenzi { get; set; }
        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetaliiComanda>()
                .HasKey(x => new { x.ProdusId, x.ComandaId });
            base.OnModelCreating(modelBuilder);
        }

    }

      }

