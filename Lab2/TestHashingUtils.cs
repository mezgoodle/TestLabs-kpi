using IIG.PasswordHashingUtils;
using System;
using Xunit;

namespace Lab2
{
    public class TestHashingUtils_Initialization
    {
        private const int adler = 14;
        private string salt = "hanzo";
        private string salt_cyrrilic = "Хандзо";
        private string salt_special = "\n\r";
        private string salt_emojies = "😀😀😀😀";
        private string salt_hieroglyphies = "汉字漢字";
        private string salt_another = "widowmaker";
        private string hash_string = "genji";

        /// <summary>
        /// Test init default proccess with parameters
        /// </summary>
        [Fact]
        public void FullParams_Initialization_NotNull()
        {
            PasswordHasher.Init(salt, adler);
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with cyrillic parameters
        /// </summary>
        [Fact]
        public void CyrillicParams_Initialization_NotNull()
        {
            PasswordHasher.Init(salt_cyrrilic, adler);
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with special parameters
        /// </summary>
        [Fact]
        public void SpecialParams_Initialization_NotNull()
        {
            PasswordHasher.Init(salt_special, adler);
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with emojies in parameters
        /// </summary>
        [Fact]
        public void EmojieParams_Initialization_NotNull()
        {
            PasswordHasher.Init(salt_emojies, adler);
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with hieroglyphies in parameters
        /// </summary>
        [Fact]
        public void HieroglyphiesParams_Initialization_NotNull()
        {
            PasswordHasher.Init(salt_hieroglyphies, adler);
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with random adler in parameters
        /// </summary>
        [Fact]
        public void RandomAlert_Initialization_NotNull()
        {
            Random adler = new Random();
            PasswordHasher.Init(salt, (uint)adler.Next());
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init default proccess with blank parameters
        /// </summary>
        [Fact]
        public void BlankParams_Initialization_NotNull()
        {
            PasswordHasher.Init("", 0);
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init proccess in GetHash method
        /// </summary>
        [Fact]
        public void DirectParams_Initialization_NotNull()
        {
            string password = PasswordHasher.GetHash(hash_string, salt, adler);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test init proccess in method and outside
        /// </summary>
        [Fact]
        public void CompareDifference_Initialization_NotNull()
        {
            string first_password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(first_password);
            PasswordHasher.Init(salt_another, adler);
            string second_password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(second_password);
            Assert.NotEqual(first_password, second_password);
        }
    }

    public class TestHashingUtils_Hashing
    {
        private const int adler = 14;
        private string salt = "hanzo";
        private string salt_cyrrilic = "Хандзо";
        private string salt_cyrrilic_1 = "Ангел";
        private string salt_special = "\n\r";
        private string salt_special_1 = "\r/r";
        private string salt_emojies = "😀😀😀😀";
        private string salt_emojies_1 = "😄 😁 😆 😅";
        private string salt_hieroglyphies = "汉字漢字";
        private string salt_hieroglyphies_1 = "字漢字字字字字字";
        private string salt_another = "tracer";
        private string hash_string = "genji";
        /// <summary>
        /// Test default hashing proccess without parameters
        /// </summary>
        [Fact]
        public void WithoutParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with parameters
        /// </summary>
        [Fact]
        public void WithParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash(hash_string, salt, adler);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with blank parameters
        /// </summary>
        [Fact]
        public void BlankParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash("", "", adler);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with cyrilic parameters
        /// </summary>
        [Fact]
        public void CyrillicParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash(salt_cyrrilic, salt_cyrrilic_1, adler);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with hieroglyphies parameters
        /// </summary>
        [Fact]
        public void HieroglyphiesParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash(salt_hieroglyphies, salt_hieroglyphies_1, adler);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with special parameters
        /// </summary>
        [Fact]
        public void SpecialParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash(salt_special, salt_special_1, adler);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with emojies parameters
        /// </summary>
        [Fact]
        public void EmojieParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash(salt_emojies, salt_emojies_1, adler);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test default hashing proccess with random adler
        /// </summary>
        [Fact]
        public void RandomAdler_Hashing_NotNull()
        {
            Random adler = new Random();
            string password = PasswordHasher.GetHash(hash_string, salt, (uint)adler.Next());
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test hashing proccess with null parameters in init
        /// </summary>
        [Fact]
        public void NullParams_Hashing_NotNull()
        {
            string password = PasswordHasher.GetHash(hash_string, null, null);
            Assert.NotNull(password);
        }

        /// <summary>
        /// Test hashing proccess with previous init and blank params in next hashing
        /// </summary>
        [Fact]
        public void PrevoiusInitZeroParams_Hashing_NotNull()
        {
            string password_with_params = PasswordHasher.GetHash(hash_string, salt, 13);
            Assert.NotNull(password_with_params);
            string password_without_params = PasswordHasher.GetHash(hash_string);
            Assert.NotNull(password_without_params);
            Assert.Equal(password_with_params, password_without_params);
        }

        /// <summary>
        /// Test hashing proccess with same parameter after another init
        /// </summary>
        [Fact]
        public void PrevoiusInitOneParam_Hashing_NotNull()
        {
            string password_with_params = PasswordHasher.GetHash(hash_string, salt, adler-1);
            string password_without_params = PasswordHasher.GetHash(hash_string);
            string password_with_one_param = PasswordHasher.GetHash(hash_string, salt);
            Assert.Equal(password_with_params, password_with_one_param);
            Assert.Equal(password_without_params, password_with_one_param);
        }

        /// <summary>
        /// Test hashing proccess with different parameter after another init
        /// </summary>
        [Fact]
        public void PrevoiusInitAnotherParam_Hashing_NotNull()
        {
            string password_without_params = PasswordHasher.GetHash(hash_string);
            string password_with_one_param = PasswordHasher.GetHash(hash_string, salt_another);
            string password_without_params_1 = PasswordHasher.GetHash(hash_string);
            Assert.Equal(password_without_params_1, password_with_one_param);
            Assert.NotEqual(password_without_params_1, password_without_params);
        }
    }
}
