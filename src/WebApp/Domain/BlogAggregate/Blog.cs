using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.SharedKernel;

namespace WebApp.Domain.BlogAggregate
{
    public class Blog : Entity, IAggregateRoot
    {
        public Blog(string name)
        {
            _insights = new List<Insight>();
            Name = name;
        }
        public string Name { get; private set; }

        [NotMapped]
        private List<Insight> _insights;
        
        public IEnumerable<Insight> Insights => _insights;

        

        public Insight AddInsight(string text)
        {
            Insight i = new Insight(text);
            _insights.Add(i);
            return i;
        }

    }
}
