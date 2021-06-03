using System;
using Xunit;
using IIG.PasswordHashingUtils;
using IIG.FileWorker;
using IIG.CoSFE.DatabaseUtils;
using IIG.BinaryFlag;

namespace Lab4
{
    public class Test_Integration_With_FileWorker
    {
        [Fact]
        public void Write_EmptyHash()
        {
            string password = "password";
            string filePath = "test.txt";
            string newHash = PasswordHasher.GetHash(password);
            bool result = BaseFileWorker.Write(newHash, filePath);
            Assert.True(result);
            string data = BaseFileWorker.ReadAll(filePath);
            Assert.Equal(newHash, data);
        }

        [Fact]
        public void Write_ModerateHash()
        {
            string password = "password";
            string salt = "salt";
            uint adler = 312;
            string filePath = "test.txt";
            string newHash = PasswordHasher.GetHash(password, salt, adler);
            bool result = BaseFileWorker.Write(newHash, filePath);
            Assert.True(result);
            string data = BaseFileWorker.ReadAll(filePath);
            Assert.Equal(newHash, data);
        }

        [Fact]
        public void TryWrite_EmptyHash()
        {
            string password = "";
            string filePath = "test.txt";
            int attempts = 3;
            string newHash = PasswordHasher.GetHash(password);
            bool result = BaseFileWorker.TryWrite(newHash, filePath, attempts);
            Assert.True(result);
            string data = BaseFileWorker.ReadAll(filePath);
            Assert.Equal(newHash, data);
        }

        [Fact]
        public void TryWrite_ModerateHash()
        {
            string password = "";
            string salt = "salt";
            uint adler = 312;
            string filePath = "test.txt";
            int attempts = 3;
            string newHash = PasswordHasher.GetHash(password, salt, adler);
            bool result = BaseFileWorker.TryWrite(newHash, filePath, attempts);
            Assert.True(result);
            string data = BaseFileWorker.ReadAll(filePath);
            Assert.Equal(newHash, data);
        }

        [Fact]
        public void ZeroTriesWrite_ModerateHash()
        {
            string password = "";
            string salt = "salt";
            uint adler = 312;
            string filePath = "test.txt";
            int attempts = 0;
            string newHash = PasswordHasher.GetHash(password, salt, adler);
            bool result = BaseFileWorker.TryWrite(newHash, filePath, attempts);
            Assert.False(result);
        }

        [Fact]
        public void ReadLines_EmptyHash()
        {
            string password = "\n\r\b\\\\/";
            string filePath = "test.txt";
            int attempts = 3;
            string newHash = PasswordHasher.GetHash(password);
            bool result = BaseFileWorker.TryWrite(newHash, filePath, attempts);
            Assert.True(result);
            string data = BaseFileWorker.ReadLines(filePath)[0];
            Assert.Equal(newHash, data);
        }

        [Fact]
        public void ReadLines_ModerateHash()
        {
            string password = "\n\r\b\\\\/";
            string salt = "salt";
            uint adler = 312;
            string filePath = "test.txt";
            int attempts = 3;
            string newHash = PasswordHasher.GetHash(password, salt, adler);
            bool result = BaseFileWorker.TryWrite(newHash, filePath, attempts);
            Assert.True(result);
            string data = BaseFileWorker.ReadLines(filePath)[0];
            Assert.Equal(newHash, data);
        }
    }

    public class Test_Integration_With_DB
    {
        private const string Server = @"GOVERLA2\SQLEXPRESS";
        private const string BinaryFlagDatabase = @"IIG.CoSWE.FlagpoleDB";
        private const bool IsTrusted = true;
        private const string Login = @"coswe";
        private const string Password = @"L}EjpfCgru9X@GLj";
        private const int ConnectionTimeout = 75;

        static readonly FlagpoleDatabaseUtils binaryFlagDatabase =
            new(Server, BinaryFlagDatabase, IsTrusted,
                Login, Password, ConnectionTimeout);

        [Fact]
        public void UIntConcreteBinaryFlagTrue()
        {
            MultipleBinaryFlag actualFlag = new MultipleBinaryFlag(2, true);
            binaryFlagDatabase.AddFlag(actualFlag.ToString(), (bool)actualFlag.GetFlag());
            int? flagIDNew = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.NotNull(flagIDNew);
            bool newFlag = binaryFlagDatabase.GetFlag((int)flagIDNew, out string flagView, out bool? flagValue);
            Assert.True(newFlag);
            Assert.Equal(flagView, actualFlag.ToString());
            Assert.Equal(flagValue, actualFlag.GetFlag());
            binaryFlagDatabase.ExecSql("DELETE FROM MultipleBinaryFlags WHERE MultipleBinaryFlagID=" + flagIDNew);
            int? flagIDEmpty = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.Null(flagIDEmpty);
        }

        [Fact]
        public void UIntConcreteBinaryFlagFalse()
        {
            MultipleBinaryFlag actualFlag = new MultipleBinaryFlag(2, false);
            binaryFlagDatabase.AddFlag(actualFlag.ToString(), (bool)actualFlag.GetFlag());
            int? flagIDNew = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.NotNull(flagIDNew);
            bool newFlag = binaryFlagDatabase.GetFlag((int)flagIDNew, out string flagView, out bool? flagValue);
            Assert.True(newFlag);
            Assert.Equal(flagView, actualFlag.ToString());
            Assert.Equal(flagValue, actualFlag.GetFlag());
            binaryFlagDatabase.ExecSql("DELETE FROM MultipleBinaryFlags WHERE MultipleBinaryFlagID=" + flagIDNew);
            int? flagIDEmpty = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.Null(flagIDEmpty);
        }

        [Fact]
        public void ULongConcreteBinaryFlagTrue()
        {
            MultipleBinaryFlag actualFlag = new MultipleBinaryFlag(65 - 1, true);
            binaryFlagDatabase.AddFlag(actualFlag.ToString(), (bool)actualFlag.GetFlag());
            int? flagIDNew = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.NotNull(flagIDNew);
            bool newFlag = binaryFlagDatabase.GetFlag((int)flagIDNew, out string flagView, out bool? flagValue);
            Assert.True(newFlag);
            Assert.Equal(flagView, actualFlag.ToString());
            Assert.Equal(flagValue, actualFlag.GetFlag());
            binaryFlagDatabase.ExecSql("DELETE FROM MultipleBinaryFlags WHERE MultipleBinaryFlagID=" + flagIDNew);
            int? flagIDEmpty = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.Null(flagIDEmpty);
        }

        [Fact]
        public void ULongConcreteBinaryFlagFalse()
        {
            MultipleBinaryFlag actualFlag = new MultipleBinaryFlag(65 - 1, false);
            binaryFlagDatabase.AddFlag(actualFlag.ToString(), (bool)actualFlag.GetFlag());
            int? flagIDNew = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.NotNull(flagIDNew);
            bool newFlag = binaryFlagDatabase.GetFlag((int)flagIDNew, out string flagView, out bool? flagValue);
            Assert.True(newFlag);
            Assert.Equal(flagView, actualFlag.ToString());
            Assert.Equal(flagValue, actualFlag.GetFlag());
            binaryFlagDatabase.ExecSql("DELETE FROM MultipleBinaryFlags WHERE MultipleBinaryFlagID=" + flagIDNew);
            int? flagIDEmpty = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.Null(flagIDEmpty);
        }

        [Fact]
        public void UIntArrayConcreteBinaryFlagTrue()
        {
            MultipleBinaryFlag actualFlag = new MultipleBinaryFlag(65 + 1, true);
            binaryFlagDatabase.AddFlag(actualFlag.ToString(), (bool)actualFlag.GetFlag());
            int? flagIDNew = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.NotNull(flagIDNew);
            bool newFlag = binaryFlagDatabase.GetFlag((int)flagIDNew, out string flagView, out bool? flagValue);
            Assert.True(newFlag);
            Assert.Equal(flagView, actualFlag.ToString());
            Assert.Equal(flagValue, actualFlag.GetFlag());
            binaryFlagDatabase.ExecSql("DELETE FROM MultipleBinaryFlags WHERE MultipleBinaryFlagID=" + flagIDNew);
            int? flagIDEmpty = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.Null(flagIDEmpty);
        }

        [Fact]
        public void UIntArrayConcreteBinaryFlagFalse()
        {
            MultipleBinaryFlag actualFlag = new MultipleBinaryFlag(65 + 1, false);
            binaryFlagDatabase.AddFlag(actualFlag.ToString(), (bool)actualFlag.GetFlag());
            int? flagIDNew = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.NotNull(flagIDNew);
            bool newFlag = binaryFlagDatabase.GetFlag((int)flagIDNew, out string flagView, out bool? flagValue);
            Assert.True(newFlag);
            Assert.Equal(flagView, actualFlag.ToString());
            Assert.Equal(flagValue, actualFlag.GetFlag());
            binaryFlagDatabase.ExecSql("DELETE FROM MultipleBinaryFlags WHERE MultipleBinaryFlagID=" + flagIDNew);
            int? flagIDEmpty = binaryFlagDatabase.GetIntBySql("SELECT MAX(MultipleBinaryFlagID) FROM MultipleBinaryFlags");
            Assert.Null(flagIDEmpty);
        }
    }
}
