using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.SharedKernel;

namespace WebApp.Domain.BlogAggregate
{
    public interface IBuyerRepository : IRepository<Blog>
    {
        Blog Add(Blog blog);
        Blog Update(Blog blog);
        Task<Blog> FindByTag(string tag);
        Task<Blog> FindByIdAsync(string id);
    }
}
