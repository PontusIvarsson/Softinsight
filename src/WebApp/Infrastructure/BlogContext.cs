using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain;
using WebApp.Domain.BlogAggregate;

namespace Infrastructure
{
    public class BlogContext : DbContext
    {
        public BlogContext (DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InsightEntityTypeConfiguration());
        }
    }

    class InsightEntityTypeConfiguration : IEntityTypeConfiguration<Insight>
    {
        public void Configure(EntityTypeBuilder<Insight> insight)
        {
            insight.OwnsMany<Hashtag>(x => x.Hashtags, hastag => {
                hastag.HasKey("InsightId", "Id");
                hastag.HasForeignKey("InsightId");
                hastag.Property<int>("Id");
            });
        }
    }
}
