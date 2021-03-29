using System;
using Xunit;
using IIG.PasswordHashingUtils;

namespace Lab2
{
    public class TestHashingUtils_Initialization
    {
        /// <summary>
        /// Test init default proccess with parameters
        /// </summary>
        [Fact]
        public void TestInitializationWithFullParams()
        {
            PasswordHasher.Init("hanzo", 14);
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with cyrillic parameters
        /// </summary>
        [Fact]
        public void TestInitializationWithFullParamsCyrillic()
        {
            PasswordHasher.Init("Хандзо", 14);
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with special parameters
        /// </summary>
        [Fact]
        public void TestInitializationWithFullParamsSpecial()
        {
            PasswordHasher.Init("\n\r", 14);
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with emojies in parameters
        /// </summary>
        [Fact]
        public void TestInitializationWithFullParamsEmojies()
        {
            PasswordHasher.Init("😀😀😀😀", 14);
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with hieroglyphies in parameters
        /// </summary>
        [Fact]
        public void TestInitializationWithFullParamsHieroglyphies()
        {
            PasswordHasher.Init("汉字漢字", 14);
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with random adler in parameters
        /// </summary>
        [Fact]
        public void TestInitializationWithFullParamsRandomAdler()
        {
            Random adler = new Random();
            PasswordHasher.Init("hanzo", (uint)adler.Next());
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with blank parameters
        /// </summary>
        [Fact]
        public void TestInitializationWithBlankParams()
        {
            PasswordHasher.Init("", 0);
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init proccess in GetHash method
        /// </summary>
        [Fact]
        public void TestDirectInitialization()
        {
            string password = PasswordHasher.GetHash("genji", "hanzo", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init proccess in method and outside
        /// </summary>
        [Fact]
        public void CompareDifferentInitializations()
        {
            string first_password = PasswordHasher.GetHash("genji");
            Assert.NotNull(first_password);
            PasswordHasher.Init("widowmaker", 14);
            string second_password = PasswordHasher.GetHash("genji");
            Assert.NotNull(second_password);
            Assert.NotEqual(first_password, second_password);
        }
    }

    public class TestHashingUtils_Hashing
    {
        /// <summary>
        /// Test default hashing proccess without parameters
        /// </summary>
        [Fact]
        public void TestHashingWithoutParams()
        {
            string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with parameters
        /// </summary>
        [Fact]
        public void TestHashingWithParams()
        {
            string password = PasswordHasher.GetHash("genji", "hanzo", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with blank parameters
        /// </summary>
        [Fact]
        public void TestHashingWithBlankParams()
        {
            string password = PasswordHasher.GetHash("", "", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with cyrilic parameters
        /// </summary>
        [Fact]
        public void TestHashingWithCyrillicParams()
        {
            string password = PasswordHasher.GetHash("Мей", "Ангел", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with hieroglyphies parameters
        /// </summary>
        [Fact]
        public void TestHashingWithHieroglyphiesParams()
        {
            string password = PasswordHasher.GetHash("汉字漢字", "字漢字字字字字字", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with special parameters
        /// </summary>
        [Fact]
        public void TestHashingWithSpecialParams()
        {
            string password = PasswordHasher.GetHash("\n/n", "\r/r", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with emojies parameters
        /// </summary>
        [Fact]
        public void TestHashingWithEmojies()
        {
            string password = PasswordHasher.GetHash("😄 😁 😆 😅", "😄 😁 😆 😅", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with random adler
        /// </summary>
        [Fact]
        public void TestHashingWithRandomAdler()
        {
            Random adler = new Random();
            string password = PasswordHasher.GetHash("genji", "hanzo", (uint)adler.Next());
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test hashing proccess with null parameters in init
        /// </summary>
        [Fact]
        public void TestHashingWithNullParams()
        {
            string password = PasswordHasher.GetHash("genji", null, null);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test hashing proccess with previous init and blank params in next hashing
        /// </summary>
        [Fact]
        public void TestHashingWithPreviousInit_AndZeroParams()
        {
            string password_with_params = PasswordHasher.GetHash("genji", "hanzo", 13);
            Assert.NotNull(password_with_params);
            string password_without_params = PasswordHasher.GetHash("genji");
            Assert.NotNull(password_without_params);
            Assert.Equal(password_with_params, password_without_params);
        }

        /// <summary>
        /// Test hashing proccess with same parameter after another init
        /// </summary>
        [Fact]
        public void TestHashingWithPrevoiusInit_AndOneParam()
        {
            string password_with_params = PasswordHasher.GetHash("genji", "hanzo", 13);
            string password_without_params = PasswordHasher.GetHash("genji");
            string password_with_one_param = PasswordHasher.GetHash("genji", "hanzo");
            Assert.Equal(password_with_params, password_with_one_param);
            Assert.Equal(password_without_params, password_with_one_param);
        }

        /// <summary>
        /// Test hashing proccess with different parameter after another init
        /// </summary>
        [Fact]
        public void TestHashingWithPrevoiusInit_AndOneAnotherParam()
        {
            string password_without_params = PasswordHasher.GetHash("genji");
            string password_with_one_param = PasswordHasher.GetHash("genji", "tracer");
            string password_without_params_1 = PasswordHasher.GetHash("genji");
            Assert.Equal(password_without_params_1, password_with_one_param);
            Assert.NotEqual(password_without_params_1, password_without_params);
        }
    }
}
