using IIG.BinaryFlag;
using System;
using Xunit;

namespace Lab3
{
    public class MultipleBinaryFlagTests
    {
        /// <summary>
        /// Test for constructor method
        /// </summary>
        public class ConstructorTests
        {
            /// <summary>
            /// Test UIntArrayConcreteBinaryFlag object creation
            /// </summary>
            [Fact]
            public void Route_0_1_3_4_6_8_9true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 1, true);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test UIntArrayConcreteBinaryFlag object creation
            /// </summary>
            [Fact]
            public void Route_0_1_3_4_6_8_9false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 1, false);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ULongConcreteBinaryFlag object creation
            /// </summary>
            [Fact]
            public void Route_0_1_3_4_6_7_9true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(64, true);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ULongConcreteBinaryFlag object creation
            /// </summary>
            [Fact]
            public void Route_0_1_3_4_6_7_9false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(64, false);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test UIntConcreteBinaryFlag object creation
            /// </summary>
            [Fact]
            public void Route_0_1_3_4_5_9true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(32, true);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test UIntConcreteBinaryFlag object creation
            /// </summary>
            [Fact]
            public void Route_0_1_3_4_5_9false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(32, false);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ArgumentOutOfRangeException exception
            /// </summary>
            [Fact]
            public void Route_0_1_3_2_9true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(17179868704 + 1, true);
                    Assert.False(true);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Assert.True(true);
                }
            }
            /// <summary>
            /// Test ArgumentOutOfRangeException exception
            /// </summary>
            [Fact]
            public void Route_0_1_3_2_9false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(17179868704 + 1, false);
                    Assert.False(true);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Assert.True(true);
                }
            }
            /// <summary>
            /// Test ArgumentOutOfRangeException exception
            /// </summary>
            [Fact]
            public void Route_0_1_2_9true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(2 - 1, true);
                    Assert.False(true);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Assert.True(true);
                }
            }
            /// <summary>
            /// Test ArgumentOutOfRangeException exception
            /// </summary>
            [Fact]
            public void Route_0_1_2_9false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(2 - 1, false);
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
            /// <summary>
            /// Test GetFlag method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_4_7_11_13true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 1, true);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.True(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test GetFlag method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_4_7_11_13false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 1, false);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.False(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test GetFlag method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_4_8_9_10_13true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, true);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.True(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test GetFlag method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_4_8_9_10_13false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, false);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.False(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test GetFlag method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_3_5_13true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, true);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.True(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test GetFlag method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_3_5_13false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, false);
                    bool? expected = obj.GetFlag();
                    Assert.NotNull(expected);
                    Assert.False(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
        }
        public class SetFlagMethodTests
        {
            /// <summary>
            /// Test SetFlag method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_9_11_12true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 123, true);
                    obj.SetFlag(100);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test SetFlag method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_9_11_12false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 123, false);
                    obj.SetFlag(100);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test SetFlag method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_6_10_12true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, true);
                    obj.SetFlag(50);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test SetFlag method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_6_10_12false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, false);
                    obj.SetFlag(50);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test SetFlag method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_4_12true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, true);
                    obj.SetFlag(20);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test SetFlag method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_4_12false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, false);
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
            /// <summary>
            /// Test ResetFlag method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_9_11_12true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 123, true);
                    obj.ResetFlag(100);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ResetFlag method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_9_11_12false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 123, false);
                    obj.ResetFlag(100);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ResetFlag method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_6_10_12true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, true);
                    obj.ResetFlag(50);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ResetFlag method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_5_6_10_12false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, false);
                    obj.ResetFlag(50);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ResetFlag method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_4_12true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, true);
                    obj.ResetFlag(20);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ResetFlag method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_4_12false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, false);
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
            /// <summary>
            /// Test Dispose method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_4_5true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, true);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test Dispose method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_4_5false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, false);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test Dispose method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_4_5true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, true);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test Dispose method with ULongConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_4_5false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 - 1, false);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test Dispose method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_3_4_5true()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 1, true);
                    obj.Dispose();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test Dispose method with UIntArrayConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void Route_0_1_2_3_4_5false()
            {
                try
                {
                    MultipleBinaryFlag obj = new(65 + 1, false);
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
            /// <summary>
            /// Test ToString method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void ToString_UIntConcreteBinaryFlag_NotNulltrue()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, true);
                    string expected = obj.ToString();
                    Assert.NotNull(expected);
                }
                catch (Exception)
                {
                    Assert.False(true);
                }
            }
            /// <summary>
            /// Test ToString method with UIntConcreteBinaryFlag object
            /// </summary>
            [Fact]
            public void ToString_UIntConcreteBinaryFlag_NotNullfalse()
            {
                try
                {
                    MultipleBinaryFlag obj = new(33 - 1, false);
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
