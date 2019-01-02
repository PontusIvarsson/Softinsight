using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Domain.BlogAggregate;
using Xunit;

namespace Softinsight.Test.Domain.BlogAggregate
{
    [Trait("Category", "Hashtag")]
    public class HashtagShould
    {
        [Fact]
        public void BeCreated()
        {
            Hashtag sut = new Hashtag("test");
            Assert.Equal("test", sut.Value);
        }

        [Theory]
        [InlineData("#a")]
        [InlineData("#aa")]
        [InlineData("#aaa")]
        public void Accept(string value)
        {
            Hashtag sut = new Hashtag(value);
            Assert.Equal(value, sut.Value);
        }

        [Theory]
        [InlineData("#a    ")]
        [InlineData("aa")]
        [InlineData("#a aa")]
        public void NotAccept(string value)
        {
            //arrange
            //act
            Action act = () => new Hashtag(value);
            //assert

            Assert.Throws<ApplicationException>(act);
        }

    }
}
