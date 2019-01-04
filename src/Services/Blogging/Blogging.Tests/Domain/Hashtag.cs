using Blogging.Domain.BlogAggregate;
using System;
using Xunit;

namespace Blogging.Tests.Domain
{

    [Trait(TestHelper.TestType, TestHelper.UnitTest)]
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
        [InlineData("a_ 1")]
        [InlineData("a a")]
        [InlineData("#a _aa")]
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
