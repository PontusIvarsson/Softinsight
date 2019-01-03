using Blogging.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogging.Domain.BlogAggregate
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog Add(Blog blog);
        Blog Update(Blog blog);
        Task<Blog> FindByTag(string tag);
        Task<List<Blog>> GetAllAsync();
    }
}
