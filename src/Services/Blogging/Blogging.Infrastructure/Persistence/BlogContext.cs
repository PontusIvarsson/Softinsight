using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Blogging.Domain.BlogAggregate;
using Blogging.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogging.Infrastructure.Persistence
{
    public class BlogContext : DbContext, IUnitOfWork
    {
        private static SqlConnectionStringBuilder Blogging =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "SoftinsightIntegrationTest",
                IntegratedSecurity = true
            };

        public BlogContext()
        {
        }
        
        public BlogContext (DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Blogging.ConnectionString);
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
