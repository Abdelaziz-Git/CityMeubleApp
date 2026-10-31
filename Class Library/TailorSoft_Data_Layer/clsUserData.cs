using Microsoft.Data.SqlClient;
using System.Data;
using TailorSoft_Models;

namespace TailorSoft_Data_Layer
{
    public class clsUserData
    {
        enum enColumns
        {
            Id,
            FirstName,
            LastName,
            Phone,
            Email,
            City,
            Username,
            PasswordHash,
            Status,
            Permissions,
            Address
        }
        enum enParameters
        {
            FirstName,
            LastName,
            Phone,
            Email,
            City,
            Username,
            PasswordHash,
            Status,
            Permissions,
            Address
        }
        enum enOutputParameters
        {
            NewUserId,
            IsUpdated,
            IsDeleted,
            IsExist
        }

        private static SqlParameter[] _CreateUserParameters(clsUserDTO user)
        {
            return new[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = user.Id },
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = user.FirstName },
                new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = user.LastName },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = user.Phone },
                new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = (object?)user.Email ?? DBNull.Value },
                new SqlParameter("@City", SqlDbType.NVarChar, 50) { Value = user.City },
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = user.Username },
                new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 256) { Value = user.PasswordHash },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = user.Status },
                new SqlParameter("@Permissions", SqlDbType.Int) { Value = user.Permissions },
                new SqlParameter("@Address", SqlDbType.NVarChar, 200) { Value = (object?)user.Address ?? DBNull.Value }
            };
        }
        private static SqlParameter _CreateOutputParameter(enOutputParameters outputParameter)
        {
            SqlParameter sqlParameter = outputParameter switch
            {
                enOutputParameters.NewUserId => new SqlParameter
                {
                    ParameterName = "@NewUserId",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                },
                enOutputParameters.IsUpdated => new SqlParameter
                {
                    ParameterName = "@IsUpdated",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                },
                enOutputParameters.IsDeleted => new SqlParameter
                {
                    ParameterName = "@IsDeleted",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                },
                enOutputParameters.IsExist => new SqlParameter
                {
                    ParameterName = "@IsExist",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                },
                _ => throw new ArgumentOutOfRangeException(nameof(outputParameter), "Invalid output parameter type")
            };
            return sqlParameter;
        }

        private static clsUserDTO _MapReaderToUserDTO(clsSqlHelper.ManagedSqlDataReader reader)
        {
            clsUserDTO userDTO = new clsUserDTO();
            userDTO.Id = reader.GetInt32((int)enColumns.Id);
            userDTO.FirstName = reader.GetString((int)enColumns.FirstName);
            userDTO.LastName = reader.GetString((int)enColumns.LastName);
            userDTO.Phone = reader.GetString((int)enColumns.Phone);
            userDTO.Email = reader.IsDBNull((int)enColumns.Email) ? null : reader.GetString((int)enColumns.Email);
            userDTO.City = reader.GetString((int)enColumns.City);
            userDTO.Username = reader.GetString((int)enColumns.Username);
            userDTO.PasswordHash = reader.GetString((int)enColumns.PasswordHash);
            userDTO.Status = reader.GetBoolean((int)enColumns.Status);
            userDTO.Permissions = reader.GetInt32((int)enColumns.Permissions);
            userDTO.Address = reader.IsDBNull((int)enColumns.Address) ? null : reader.GetString((int)enColumns.Address);
            return userDTO;
        }
        private static List<clsUserDTO> _MapReaderToUserDTOs(clsSqlHelper.ManagedSqlDataReader reader)
        {
            List<clsUserDTO> usersDTOs = new List<clsUserDTO>();
            while (reader.Read())
            {
                usersDTOs.Add(_MapReaderToUserDTO(reader));
            }
            return usersDTOs;
        }
        public static int? AddNewUser(clsUserDTO userDTO)
        {
            try
            {
                if (clsDatabaseSettings.DefaultConnection == null)
                {
                    throw new Exception("Database connection string is not set.");
                }
                SqlParameter[] parameters = _CreateUserParameters(userDTO) // Create parameters from userDTO
                    .Append(_CreateOutputParameter(enOutputParameters.NewUserId)) // Append output parameter for NewUserId
                    .SkipWhile(p => p.ParameterName == "@Id") // Skip the Id parameter as it's not needed for insertion
                    .ToArray(); // Convert to array

                object? NewUserId = clsSqlHelper.ExecuteNonQuery(clsDatabaseSettings.DefaultConnection, "dbo.SP_User_AddNew", parameters);

                if (NewUserId != null && NewUserId != DBNull.Value)
                    return (int)NewUserId;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static clsUserDTO? GetUserByUsername(string username)
        {
            clsUserDTO userDTO;
            try
            {
                if (clsDatabaseSettings.DefaultConnection == null)
                {
                    throw new Exception("Database connection string is not set.");
                }
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = username }
                };
                using (clsSqlHelper.ManagedSqlDataReader reader = clsSqlHelper.ExecuteReader(clsDatabaseSettings.DefaultConnection, "dbo.SP_User_GetByUsername", parameters))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        userDTO = _MapReaderToUserDTO(reader);
                        return userDTO;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user by username", ex);
            }
        }
        public static List<clsUserDTO> GetAllUsers()
        {
            List<clsUserDTO> usersDTOs;
            try
            {
                if (clsDatabaseSettings.DefaultConnection == null)
                {
                    throw new Exception("Database connection string is not set.");
                }
                using (clsSqlHelper.ManagedSqlDataReader reader = clsSqlHelper.ExecuteReader(clsDatabaseSettings.DefaultConnection, "dbo.SP_User_GetAll"))
                {
                    usersDTOs = _MapReaderToUserDTOs(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all users", ex);
            }
            return usersDTOs;
        }
        public static clsUserDTO? GetUserById(int id)
        {
            clsUserDTO userDTO;
            try
            {
                if (clsDatabaseSettings.DefaultConnection == null)
                {
                    throw new Exception("Database connection string is not set.");
                }
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                using (clsSqlHelper.ManagedSqlDataReader reader = clsSqlHelper.ExecuteReader(clsDatabaseSettings.DefaultConnection, "dbo.SP_User_GetById", parameters))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        userDTO = _MapReaderToUserDTO(reader);
                        return userDTO;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user by ID", ex);
            }
        }
        public static bool UpdateUser(clsUserDTO userDTO)
        {
            bool IsUpdated = false;
            try
            {
                if (clsDatabaseSettings.DefaultConnection == null)
                {
                    throw new Exception("Database connection string is not set.");
                }
                object? result = clsSqlHelper.ExecuteNonQuery
                    (clsDatabaseSettings.DefaultConnection,
                    "dbo.SP_User_Update",
                    _CreateUserParameters(userDTO).Append(_CreateOutputParameter(enOutputParameters.IsUpdated)).ToArray());
                if (result != null && result != DBNull.Value)
                    IsUpdated = Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user", ex);
            }
            return IsUpdated;
        }
        public static bool IsUsernameExist(string username)
        {
            bool IsExist = false;
            try
            {
                if (clsDatabaseSettings.DefaultConnection == null)
                {
                    throw new Exception("Database connection string is not set.");
                }
                object? result = clsSqlHelper.ExecuteNonQuery
                    (clsDatabaseSettings.DefaultConnection,
                    "dbo.SP_User_IsUsernameExist",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = username },
                        _CreateOutputParameter(enOutputParameters.IsExist)
                    });
                if (result != null && result != DBNull.Value)
                    IsExist = Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking if username exists", ex);
            }
            return IsExist;

        }
        public static bool DeleteUser(int id)
        {
            bool IsDeleted = false;
            try
            {
                if (clsDatabaseSettings.DefaultConnection == null)
                {
                    throw new Exception("Database connection string is not set.");
                }
                object? result = clsSqlHelper.ExecuteNonQuery
                    (clsDatabaseSettings.DefaultConnection,
                    "dbo.SP_User_Delete",
                    new SqlParameter[]
                    {
                        new SqlParameter("@Id", SqlDbType.Int) { Value = id },
                        _CreateOutputParameter(enOutputParameters.IsDeleted)
                    });
                if (result != null && result != DBNull.Value)
                    IsDeleted = Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting user", ex);
            }
            return IsDeleted;
        }
    }
}
