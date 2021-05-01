using System;
using Xunit;
using IIG.BinaryFlag;

namespace Lab3
{
    public class TestBinaryFlag
    {
        [Fact]
        public void Test1()
        {
            MultipleBinaryFlag obj = new MultipleBinaryFlag(32);
            Console.WriteLine(obj);
            Assert.Null(null);
        }
    }
}
