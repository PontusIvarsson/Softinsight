using Blogging.Domain.BlogAggregate;
using Blogging.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;



namespace Blogging.Tests.Domain
{


    [Trait(TestHelper.TestType, TestHelper.IntegrationTest)]
    public class BlogRepository_Should : IClassFixture<EfFixture>
    {
        ITestOutputHelper _output;
        BlogContext _blogContext;
        BlogRepository _blogRepository;

        public BlogRepository_Should(ITestOutputHelper output, EfFixture efFixture)
        {
            _blogContext = efFixture.BlogContext;
            _blogRepository = efFixture.BlogRepository;
            _output = output;
            _output.WriteLine(efFixture.Guid);
        }
        

        [Fact]
        public async Task Be_Created()
        {
            var _blog = new Blog("first blog");

            _blogRepository.Add(_blog);
            await _blogRepository.UnitOfWork.SaveEntitiesAsync();
            Assert.True(_blog.Id > 0);
        }


        [Fact]
        public void Add_Insight()
        {
            //arrange
            Blog blog = new Blog("test");
            _blogContext.Add(blog);
            _blogContext.SaveChanges();

            //act
            var sut = _blogContext.Blog.Find(blog.Id);
            sut.AddInsight("test");
            _blogContext.SaveChanges();

            //assert
            Assert.True(sut.Insights.FirstOrDefault().Id > 0);
        }

        
        [Fact]
        public void Should_Include_Insights_when_any_Repo()
        {
            var blogContext = new BlogContext();
            _output.WriteLine(blogContext.UniqeId);
            var guid = "uniqe"; Guid.NewGuid().ToString();

            //arrange
            Blog blog = new Blog(guid);
            blog.AddInsight(guid);
            blogContext.Add(blog);
            blogContext.SaveChanges();
            
            //act -- we want to test include statement.
            var sut = _blogRepository.FindByIdAsync(blog.Id).Result;
            _output.WriteLine(_blogRepository._context.UniqeId);

            //assert
            Assert.True(sut.Insights.Count() > 0);
        }
    }
}
