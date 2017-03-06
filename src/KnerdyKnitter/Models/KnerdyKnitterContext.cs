using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    public class KnerdyKnitterContext : IdentityDbContext<ApplicationUser>
    {
        public KnerdyKnitterContext()
        {
        }

        public virtual DbSet<Knitter> Knitters { get; set; }
        public virtual DbSet<Garment> Garments { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<GarmentTag> GarmentTags { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=KnerdyKnitter;integrated security=True");
        }

        public KnerdyKnitterContext(DbContextOptions<KnerdyKnitterContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
