using Blogging.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace Blogging.Domain.BlogAggregate
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
