using System;
using Xunit;
using IIG.PasswordHashingUtils;
using IIG.FileWorker;
using IIG.CoSFE.DatabaseUtils;
using IIG.BinaryFlag;

namespace Lab4
{
    public class UnitTest1
    {
    public class Database
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
        public void MinimumTrueFlag()
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
    }
}
