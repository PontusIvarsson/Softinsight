using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.SharedKernel;

namespace WebApp.Domain.BlogAggregate
{
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
