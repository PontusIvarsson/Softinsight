using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.SharedKernel;

namespace WebApp.Domain
{
    public class Blog : Entity
    {

        public Blog(string name)
        {
            _insights = new List<Insight>();
            Name = name;
        }
        public string Name { get; private set; }

        private List<Insight> _insights;
        public IEnumerable<Insight> Insights => _insights;

        public Insight AddInsight(string text)
        {
            Insight i = new Insight(text);
            _insights.Add(i);
            return i;
        }

    }

    public class Insight
    {
        private Insight() { }
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

    public class Hashtag : ValueObject
    {
        int InsightId;
        int Id;
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
