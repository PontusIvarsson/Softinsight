using Blog.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Blogging.Tests.Domain
{
    [Trait(TestHelper.TestType, TestHelper.IntegrationTest)]
    public class Blog_Should
    {

        [Trait(TestHelper.TestType, TestHelper.UnitTest)]
        [Fact]
        public void Be_Created()
        {

        }

        [Trait(TestHelper.TestType, TestHelper.IntegrationTest)]
        [Fact]
        public void Be_Created_In_DataBase()
        {

        }
    }
}
