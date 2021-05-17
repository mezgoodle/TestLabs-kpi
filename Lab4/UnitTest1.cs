using System;
using IIG.DatabaseConnectionUtils;
using IIG.CoSFE.DatabaseUtils;
using IIG.PasswordHashingUtils;
using System.Text;

namespace Lab4
{
	class Program
	{
		private const string Server = @"GOVERLA2";
		private const string StorageDatabase = @"IIG.CoSWE.StorageDB";
		private const bool IsTrusted = true;
		private const string Login = @"coswe";
		private const string Password = @"L}EjpfCgru9X@GLj";
		private const int ConnectionTimeout = 75;

		static StorageDatabaseUtils storageDatabase = new(Server, StorageDatabase,
			IsTrusted, Login, Password, ConnectionTimeout);

		static void Main()
		{
			storageDatabase.DeleteFile(1);
			storageDatabase.DeleteFile(2);
			storageDatabase.DeleteFile(3);
			storageDatabase.DeleteFile(4);
			storageDatabase.DeleteFile(5);

			string array = "Some String";

			byte[] bytes = Encoding.UTF8.GetBytes(array);

			Console.WriteLine(storageDatabase.AddFile("SomeCoolName.txt", bytes));

			Console.WriteLine(storageDatabase.GetFile(1, out string newName,
				out byte[] newBytes));

			string newArray = Encoding.UTF8.GetString(newBytes);
			Console.WriteLine(newArray);

			storageDatabase.DeleteFile(1);
			storageDatabase.DeleteFile(2);
			storageDatabase.DeleteFile(3);
			storageDatabase.DeleteFile(4);
			storageDatabase.DeleteFile(5);
		}
	}
}
