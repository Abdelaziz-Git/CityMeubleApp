using Microsoft.Data.SqlClient;
using System.Data;

namespace TailorSoft_Data_Layer
{
    internal static class clsSqlHelper
    {
        internal sealed class ManagedSqlDataReader : IDisposable
        {
            private readonly SqlDataReader _reader;
            private readonly SqlCommand _command;
            private readonly SqlConnection _connection;

            public ManagedSqlDataReader(SqlDataReader reader, SqlCommand command, SqlConnection connection)
            {
                _reader = reader;
                _command = command;
                _connection = connection;
            }

            public bool HasRows => _reader.HasRows;
            public bool Read() => _reader.Read();
            public object GetValue(int ordinal) => _reader.GetValue(ordinal);
            public int GetInt32(int ordinal) => _reader.GetInt32(ordinal);
            public string GetString(int ordinal) => _reader.GetString(ordinal);
            public bool GetBoolean(int ordinal) => _reader.GetBoolean(ordinal);
            public bool IsDBNull(int ordinal) => _reader.IsDBNull(ordinal);

            public void Dispose()
            {
                _reader?.Dispose();
                _command?.Dispose();
                _connection?.Dispose();
            }
        }

        public static object? ExecuteNonQuery(string connectionString, string storedProcedure, SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string is required.", nameof(connectionString));

            using SqlConnection conn = new(connectionString);
            using SqlCommand cmd = new(storedProcedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters?.Length > 0)
                cmd.Parameters.AddRange(parameters);

            conn.Open();
            cmd.ExecuteNonQuery();

            return parameters?
                .FirstOrDefault(p => p.Direction == ParameterDirection.Output)
                ?.Value;
        }

        public static ManagedSqlDataReader ExecuteReader(string connectionString, string storedProcedure, SqlParameter[]? parameters = null)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string is required.", nameof(connectionString));

            SqlConnection conn = new(connectionString);
            SqlCommand cmd = new(storedProcedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters?.Length > 0)
                cmd.Parameters.AddRange(parameters);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return new ManagedSqlDataReader(reader, cmd, conn);
        }
    }
}
