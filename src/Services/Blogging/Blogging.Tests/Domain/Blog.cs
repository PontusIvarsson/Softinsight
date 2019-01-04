using Blogging.Domain.BlogAggregate;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace Blogging.Tests.Domain
{
    [Trait(TestHelper.TestType, TestHelper.IntegrationTest)]
    public class Blog_Should : IClassFixture<EfFixture>
    {
        ITestOutputHelper output;
        EfFixture efFixture;

        public Blog_Should(ITestOutputHelper output, EfFixture efFixture)
        {
            this.efFixture = efFixture;
            this.output = output;
        }


        [Fact]
        public void Be_Created()
        {
            output.WriteLine(efFixture.Guid);
        }


        [Fact]
        public async Task Be_Created_In_DataBaseAsync()
        {
            var blog = new Blog("first blog");

            efFixture.BlogRepository.Add(blog);
            await efFixture.BlogRepository.UnitOfWork.SaveEntitiesAsync();
            
            Assert.Equal(1, blog.Id);
            
        }
    }
}
