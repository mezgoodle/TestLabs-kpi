using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using IIG.DatabaseConnectionUtils;

namespace IIG.CoSFE.DatabaseUtils
{
    public class StorageDatabaseUtils : DatabaseConnection
    {
        public StorageDatabaseUtils(NameValueCollection appSettings) : base(appSettings)
        {
        }

        public StorageDatabaseUtils(string server, string database, bool isTrusted, string login = null,
            string password = null, int connectionTimeOut = 15) : base(server, database, isTrusted, login, password,
            connectionTimeOut)
        {
        }

        public bool AddFile(string fileName, byte[] fileContent)
        {
            if (!ConnectToDatabase())
                return false;

            bool res;

            using (var cmd = new SqlCommand("[dbo].[AddFile]", Connection))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FileName", SqlDbType.NVarChar, 300).Value = fileName;
                    cmd.Parameters.Add("@FileContent", SqlDbType.VarBinary, 1024).Value = fileContent;
                    cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    res = Convert.ToBoolean(cmd.Parameters["@Result"].Value);
                }
                catch
                {
                    res = false;
                }
                finally
                {
                    Connection.Close();
                }
            }

            return res;
        }

        public bool DeleteFile(int fileId)
        {
            if (!ConnectToDatabase())
                return false;

            bool res;

            using (var cmd = new SqlCommand("[dbo].[DeleteFile]", Connection))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FileID", SqlDbType.Int).Value = fileId;
                    cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    res = Convert.ToBoolean(cmd.Parameters["@Result"].Value);
                }
                catch
                {
                    res = false;
                }
                finally
                {
                    Connection.Close();
                }
            }

            return res;
        }

        public bool GetFile(int fileId, out string fileName, out byte[] fileContent)
        {
            fileName = null;
            fileContent = null;
            var dt = GetDataTableBySql($"EXECUTE [dbo].[GetFile] {fileId}");
            if (dt == null || dt.Rows.Count != 1)
                return false;
            var itemArray = dt.Rows[0].ItemArray;
            fileName = itemArray[1] as string;
            fileContent = itemArray[2] as byte[];
            return true;
        }

        public DataTable GetFiles(string fileName = null)
        {
            fileName = string.IsNullOrEmpty(fileName) ? "NULL" : $"'{fileName}'";
            return GetDataTableBySql($"EXECUTE [dbo].[GetFiles] {fileName}");
        }
    }
}