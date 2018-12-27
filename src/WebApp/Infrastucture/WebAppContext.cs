using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain;

namespace Infrastructure
{
    public class WebAppContext : DbContext
    {
        public WebAppContext (DbContextOptions<WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp.Domain.Blog> Blog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InsightEntityTypeConfiguration());
        }
    }

    class InsightEntityTypeConfiguration : IEntityTypeConfiguration<Insight>
    {
        public void Configure(EntityTypeBuilder<Insight> builder)
        {
            builder.OwnsMany<Hashtag>(x => x.Hashtags, a => {
                a.HasForeignKey("InsightId");
                a.Property<int>("Id");
                a.HasKey("InsightId", "Id");
            });
        }
    }
}
