using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Queries
{
    public class BlogSearchResult
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public int InsightId { get; set; }
        public string Hashtag { get; set; }
    }
}
