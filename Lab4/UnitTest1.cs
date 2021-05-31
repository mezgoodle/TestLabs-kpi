using System;
using Xunit;
using IIG.CoSFE.DatabaseUtils;
using IIG.PasswordHashingUtils;

namespace Lab4
{
    public class UnitTest1
    {
        private const string Server = @"GOVERLA2\SQLEXPRESS";
        private const string AuthDatabase = @"IIG.CoSWE.AuthDB";
        private const string StorageDatabase = @"IIG.CoSWE.StorageDB";
        private const bool IsTrusted = true;
        private const string Login = @"coswe";
        private const string Password = @"L}EjpfCgru9X@GLj";
        private const int ConnectionTimeout = 75;

        static readonly AuthDatabaseUtils authDatabase =
            new(Server, AuthDatabase, IsTrusted,
                Login, Password, ConnectionTimeout);

        [Fact]
        public void Test1()
        {
            string login = "login";
            string pass = "hashedPass";

            string pass1 = PasswordHasher.GetHash(pass);

            authDatabase.AddCredentials(login, pass1);

            bool areCredentialsTheSame = authDatabase.CheckCredentials(login, pass1);

            authDatabase.DeleteCredentials(login, pass1);

            // Assert
            Assert.True(areCredentialsTheSame);
        }
    }
}