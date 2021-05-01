using System;
using Xunit;
using IIG.BinaryFlag;

namespace Lab3
{
    public class MultipleBinaryFlagConstructorTests
    {
        [Fact]
        public void Route_0_1_3_4_6_8_9()
        {
            try
            {
                MultipleBinaryFlag obj = new MultipleBinaryFlag(66);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.False(true);
            }
        }
    }
}
