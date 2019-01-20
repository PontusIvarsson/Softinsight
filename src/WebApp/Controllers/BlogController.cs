using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {

        IBlogQueries _blogQueries;
        public BlogController(IBlogQueries blogQueries)
        {
            _blogQueries = blogQueries;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<BlogSearchResult> Get(string searchTag)
        {
            var a = _blogQueries.GetBlogsContainingTag(searchTag);
            return a.Result;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
