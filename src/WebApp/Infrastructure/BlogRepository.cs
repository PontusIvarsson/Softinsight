using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.BlogAggregate;
using WebApp.Domain.SharedKernel;

namespace WebApp.Infrastructure
{
    public class BlogRepository : IBlogRepository
    {

        private BlogContext _context;
        public IUnitOfWork UnitOfWork { get { return _context; } }

        public BlogRepository(BlogContext unitOfWork)
        {
            _context = unitOfWork;
        }
        
        public Blog Add(Blog blog)
        {
            var a = _context.Blog.Add(blog);
            return a.Entity;
        }

        public Task<Blog> FindByIdAsync(int id)
        {
            var blog = _context.Blog.Include(x => x.Insights)
                .FirstOrDefaultAsync(m => m.Id == id);
           

            return blog;
        }

        public Task<Blog> FindByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public Blog Update(Blog blog)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blog.ToListAsync();
        }
        
    }
}
