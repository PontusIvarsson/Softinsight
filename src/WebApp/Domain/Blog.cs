using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain
{
    public class Blog
    {
        public Blog(string name)
        {
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }

        private List<Insight> _insights;
        public ICollection<Insight> Insights { get; set; }

        public void AddInsight(string text)
        {
            Insight i = new Insight(text);
            _insights.Add(i);
        }

    }

    public class Insight
    {
        private Insight() { }
        public Insight(string text)
        {
            Text = text;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Text { get; private set; }

        private List<Hashtag> _tags;

        [NotMapped]
        public ICollection<Hashtag> Hashtags { get; private set; }


        public void AddTag(Hashtag tag)
        {
            if (_tags.Contains(tag))
                throw new ApplicationException("Already contains tag.");
            Hashtags.Add(tag);
        }

    }

    public class Hashtag : ValueObject
    {
        public Hashtag(string value)
        {
            //todo: add valid validation =)
            if (value.Contains(' '))
            {

                throw new ApplicationException("Tags can only contain a-z an");
            }
            Value = value;
        }
        public string Value { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
