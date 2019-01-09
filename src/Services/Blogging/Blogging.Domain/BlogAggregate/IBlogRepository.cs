using Blogging.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogging.Domain.BlogAggregate
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog Add(Blog blog);
    }
}
