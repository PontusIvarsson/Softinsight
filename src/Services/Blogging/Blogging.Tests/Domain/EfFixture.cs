using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using Blogging.Infrastructure.Persistence;




namespace Blogging.Tests.Domain
{
    public class EfFixture : IDisposable
    {


        public EfFixture()
        {
            Guid = System.Guid.NewGuid().ToString();

            var blogContext = new BlogContext();
            var blogRepository = new BlogRepository(blogContext);
            BlogContext = blogContext;
            BlogRepository = blogRepository;

            blogContext.Database.EnsureDeleted();
            blogContext.Database.Migrate();
            
        }

        public void Dispose()
        {

        }

        public BlogContext BlogContext { get; private set; }
        public BlogRepository BlogRepository { get; private set; }
        public string Guid { get; private set; }
    }
}
