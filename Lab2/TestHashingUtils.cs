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
        public void FullParams_Initialization_NotNull()
        {
            PasswordHasher.Init("hanzo", 14);
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with cyrillic parameters
        /// </summary>
        [Fact]
        public void CyrillicParams_Initialization_NotNull()
        {
            PasswordHasher.Init("Хандзо", 14);
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with special parameters
        /// </summary>
        [Fact]
        public void SpecialParams_Initialization_NotNull()
        {
            PasswordHasher.Init("\n\r", 14);
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with emojies in parameters
        /// </summary>
        [Fact]
        public void EmojieParams_Initialization_NotNull()
        {
            PasswordHasher.Init("😀😀😀😀", 14);
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with hieroglyphies in parameters
        /// </summary>
        [Fact]
        public void HieroglyphiesParams_Initialization_NotNull()
        {
            PasswordHasher.Init("汉字漢字", 14);
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with random adler in parameters
        /// </summary>
        [Fact]
        public void RandomAlert_Initialization_NotNull()
        {
            Random adler = new Random();
            PasswordHasher.Init("hanzo", (uint)adler.Next());
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with blank parameters
        /// </summary>
        [Fact]
        public void BlankParams_Initialization_NotNull()
        {
            PasswordHasher.Init("", 0);
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init proccess in GetHash method
        /// </summary>
        [Fact]
        public void DirectParams_Initialization_NotNull()
        {
            const string password = PasswordHasher.GetHash("genji", "hanzo", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init proccess in method and outside
        /// </summary>
        [Fact]
        public void CompareDifference_Initialization_NotNull()
        {
            const string first_password = PasswordHasher.GetHash("genji");
            Assert.NotNull(first_password);
            PasswordHasher.Init("widowmaker", 14);
            const string second_password = PasswordHasher.GetHash("genji");
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
        public void WithoutParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("genji");
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with parameters
        /// </summary>
        [Fact]
        public void WithParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("genji", "hanzo", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with blank parameters
        /// </summary>
        [Fact]
        public void BlankParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("", "", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with cyrilic parameters
        /// </summary>
        [Fact]
        public void CyrillicParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("Мей", "Ангел", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with hieroglyphies parameters
        /// </summary>
        [Fact]
        public void HieroglyphiesParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("汉字漢字", "字漢字字字字字字", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with special parameters
        /// </summary>
        [Fact]
        public void SpecialParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("\n/n", "\r/r", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with emojies parameters
        /// </summary>
        [Fact]
        public void EmojieParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("😄 😁 😆 😅", "😄 😁 😆 😅", 14);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with random adler
        /// </summary>
        [Fact]
        public void RandomAdler_Hashing_NotNull()
        {
            Random adler = new Random();
            const string password = PasswordHasher.GetHash("genji", "hanzo", (uint)adler.Next());
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test hashing proccess with null parameters in init
        /// </summary>
        [Fact]
        public void NullParams_Hashing_NotNull()
        {
            const string password = PasswordHasher.GetHash("genji", null, null);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test hashing proccess with previous init and blank params in next hashing
        /// </summary>
        [Fact]
        public void PrevoiusInitZeroParams_Hashing_NotNull()
        {
            const string password_with_params = PasswordHasher.GetHash("genji", "hanzo", 13);
            Assert.NotNull(password_with_params);
            const string password_without_params = PasswordHasher.GetHash("genji");
            Assert.NotNull(password_without_params);
            Assert.Equal(password_with_params, password_without_params);
        }

        /// <summary>
        /// Test hashing proccess with same parameter after another init
        /// </summary>
        [Fact]
        public void PrevoiusInitOneParam_Hashing_NotNull()
        {
            const string password_with_params = PasswordHasher.GetHash("genji", "hanzo", 13);
            const string password_without_params = PasswordHasher.GetHash("genji");
            const string password_with_one_param = PasswordHasher.GetHash("genji", "hanzo");
            Assert.Equal(password_with_params, password_with_one_param);
            Assert.Equal(password_without_params, password_with_one_param);
        }

        /// <summary>
        /// Test hashing proccess with different parameter after another init
        /// </summary>
        [Fact]
        public void PrevoiusInitAnotherParam_Hashing_NotNull()
        {
            const string password_without_params = PasswordHasher.GetHash("genji");
            const string password_with_one_param = PasswordHasher.GetHash("genji", "tracer");
            const string password_without_params_1 = PasswordHasher.GetHash("genji");
            Assert.Equal(password_without_params_1, password_with_one_param);
            Assert.NotEqual(password_without_params_1, password_without_params);
        }
    }
}
