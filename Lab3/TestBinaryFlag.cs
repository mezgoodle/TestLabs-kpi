using IIG.BinaryFlag;
using System;
using Xunit;

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
        [Fact]
        public void Route_0_1_3_4_6_7_9()
        {
            try
            {
                MultipleBinaryFlag obj = new MultipleBinaryFlag(64);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.False(true);
            }
        }
        [Fact]
        public void Route_0_1_3_4_5_9()
        {
            try
            {
                MultipleBinaryFlag obj = new MultipleBinaryFlag(32);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.False(true);
            }
        }
        [Fact]
        public void Route_0_1_3_2_9()
        {
            try
            {
                MultipleBinaryFlag obj = new MultipleBinaryFlag(17179868704 + 1);
                Assert.False(true);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void Route_0_1_2_9()
        {
            try
            {
                MultipleBinaryFlag obj = new MultipleBinaryFlag(2-1);
                Assert.False(true);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }
    }
}
