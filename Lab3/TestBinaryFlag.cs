using IIG.BinaryFlag;
using System;
using Xunit;

namespace Lab3
{
    public class MultipleBinaryFlagTests
    {
        public class ConstructorTests
        {
            [Fact]
            public void Route_0_1_3_4_6_8_9()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 + 1);
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
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(2 - 1);
                    Assert.False(true);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Assert.True(true);
                }
            }
        }

        public class GetFlagMethodTests
        {
            [Fact]
            public void Route_0_1_4_7_11_13()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 + 1);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.True(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_4_8_9_10_13()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 - 1);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.True(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_2_3_5_13()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(33 - 1);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.True(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
        }
        public class SetFlagMethodTests
        {
            [Fact]
            public void Route_0_1_5_9_11_12()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 + 123);
                    obj.SetFlag(100);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_5_6_10_12()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 - 1);
                    obj.SetFlag(50);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_2_4_12()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(33 - 1);
                    obj.SetFlag(20);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
        }
        public class ResetFlagMethodTests
        {
            [Fact]
            public void Route_0_1_5_9_11_12()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 + 123);
                    obj.ResetFlag(100);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_5_6_10_12()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 - 1);
                    obj.ResetFlag(50);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_2_4_12()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(33 - 1);
                    obj.ResetFlag(20);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
        }
        public class DisposeMethodTests
        {
            [Fact]
            public void Route_0_1_4_5()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(33 - 1);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_2_4_5()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 - 1);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            [Fact]
            public void Route_0_1_2_3_4_5()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(65 + 1);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
        }
        public class ToStringMethodTests
        {
            [Fact]
            public void ToString_NotNull()
            {
                try
                {
                    MultipleBinaryFlag obj = new MultipleBinaryFlag(33 - 1);
                    string expected = obj.ToString();
                    Assert.NotNull(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
        }
    }
}
