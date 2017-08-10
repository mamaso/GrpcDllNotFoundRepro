using GrpcLib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProj
{
    public class TestClass: IClassFixture<Fixture>
    {
        [Fact]
        public void Test()
        {
            Assert.True(true);
        }
    }

    public class Fixture
    {
        public Fixture()
        {
            var testServer = new GrpcServer();
        }
    }
}
