using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain;
using WebApp.Domain.BlogAggregate;
using WebApp.Domain.SharedKernel;

namespace Infrastructure
{
    public class BlogContext : DbContext, IUnitOfWork
    {
        public BlogContext (DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blog { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
 
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            //await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync();

            return true;
        }

        

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
