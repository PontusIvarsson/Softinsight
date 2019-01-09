using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Domain.BlogAggregate
{
    public class Insight
    {
        public Insight(string text)
        {
            _hashtags = new HashSet<Hashtag>();
            Text = text;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Text { get; private set; }

        private HashSet<Hashtag> _hashtags;

        public IEnumerable<Hashtag> Hashtags => _hashtags;

        public void AddTag(Hashtag tag)
        {
            if (_hashtags.Contains(tag))
                throw new ApplicationException("Already contains tag.");
            _hashtags.Add(tag);
        }
    }
}
