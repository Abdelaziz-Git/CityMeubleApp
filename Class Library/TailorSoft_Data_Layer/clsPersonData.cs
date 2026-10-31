using Microsoft.Data.SqlClient;
using System.Data;
using TailorSoft_Models;

namespace TailorSoft_Data_Layer
{
    /// <summary>
    /// Provides data access methods for managing person records in the database.
    /// </summary>
    public class clsPersonData
    {
        /// <summary>
        /// Enumeration of column indices for mapping data from a <see cref="SqlDataReader"/> to a <see cref="clsPersonDTO"/>.
        /// </summary>
        enum enColumn
        {
            Id, FirstName, LastName, Phone, Email, Adress
        }

        /// <summary>
        /// Maps the current row of a <see cref="SqlDataReader"/> to a <see cref="clsPersonDTO"/> instance.
        /// </summary>
        /// <param name="reader">The SQL data reader positioned at a person record.</param>
        /// <returns>A <see cref="clsPersonDTO"/> populated with data from the reader, or <see langword="null"/> if no data is available.</returns>
        private static clsPersonDTO? _MapReaderToPersonDTO(SqlDataReader reader)
        {
            clsPersonDTO personDTO;
            if (reader.Read())
            {
                personDTO = new clsPersonDTO();
                personDTO.Id = reader.GetInt32((byte)enColumn.Id);
                personDTO.FirstName = reader.IsDBNull((byte)enColumn.FirstName) ? string.Empty : reader.GetString((byte)enColumn.FirstName);
                personDTO.LastName = reader.IsDBNull((byte)enColumn.LastName) ? string.Empty : reader.GetString((byte)enColumn.LastName);
                personDTO.Phone = reader.IsDBNull((byte)enColumn.Phone) ? string.Empty : reader.GetString((byte)enColumn.Phone);
                personDTO.Email = reader.IsDBNull((byte)enColumn.Email) ? null : reader.GetString((byte)enColumn.Email);
                personDTO.Address = reader.IsDBNull((byte)enColumn.Adress) ? null : reader.GetString((byte)enColumn.Adress);
                return personDTO;
            }
            return null;
        }

        /// <summary>
        /// Sets the parameters for a <see cref="SqlCommand"/> using the values from a <see cref="clsPersonDTO"/> instance.
        /// </summary>
        /// <param name="command">The SQL command to which parameters will be added.</param>
        /// <param name="personDTO">The person data transfer object containing parameter values.</param>
        private static void _SetCommandParameters(SqlCommand command, clsPersonDTO personDTO)
        {
            command.Parameters.AddWithValue("@FirstName", personDTO.FirstName);
            command.Parameters.AddWithValue("@LastName", personDTO.LastName);
            command.Parameters.AddWithValue("@Phone", personDTO.Phone);
            command.Parameters.AddWithValue("@Email", personDTO.Email);
            command.Parameters.AddWithValue("@Adrress", personDTO.Address);
        }

        /// <summary>
        /// Adds a new person to the database using the provided <see cref="clsPersonDTO"/>.
        /// Executes the "SP_Person_AddNew" stored procedure and returns the newly created PersonID if successful.
        /// </summary>
        /// <param name="personDTO">The person data transfer object containing person details to add.</param>
        /// <returns>The PersonID of the newly added person if successful; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while adding the person.</exception>
        public static int? AddNewPerson(clsPersonDTO personDTO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Person_AddNew", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        _SetCommandParameters(cmd, personDTO);
                        SqlParameter OutputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(OutputIdParam);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        object obj = cmd.Parameters["@NewPersonID"].Value;
                        if (obj != null && obj != DBNull.Value)
                        {
                            return (int)obj;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Retrieves a person by their unique identifier.
        /// </summary>
        /// <param name="personID">The unique identifier of the person to retrieve.</param>
        /// <returns>An instance of <see cref="clsPersonDTO"/> representing the person if found; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while retrieving the person from the database.</exception>
        public static clsPersonDTO? GetPersonByID(int personID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Person_GetByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", personID);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return _MapReaderToPersonDTO(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting person by id.", ex);
            }
        }

        /// <summary>
        /// Retrieves a person by their phone number.
        /// </summary>
        /// <param name="phone">The phone number of the person to retrieve.</param>
        /// <returns>An instance of <see cref="clsPersonDTO"/> representing the person if found; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while retrieving the person from the database.</exception>
        public static clsPersonDTO? GetPersonByPhone(string phone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Person_GetByPhone", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return _MapReaderToPersonDTO(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting person by phone.", ex);
            }
        }
        public static bool IsPersonExists(string phone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Person_IsExistByPhone", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        conn.Open();
                        return (bool)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking if person exists.", ex);
            }
        }

        /// <summary>
        /// Updates an existing person in the database using the provided <see cref="clsPersonDTO"/>.
        /// Executes the "SP_Person_Update" stored procedure.
        /// </summary>
        /// <param name="personDTO">The person data transfer object containing updated person details.</param>
        /// <returns><see langword="true"/> if the person was updated successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while updating the person.</exception>
        public static bool UpdatePerson(clsPersonDTO personDTO)
        {
            if (personDTO == null)
                return false;
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Person_Update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", personDTO.Id);
                        _SetCommandParameters(cmd, personDTO);
                        SqlParameter OutputRowsAffectedParam = new SqlParameter()
                        {
                            ParameterName = "@RowsAffected",
                            DbType = DbType.Int32,
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(OutputRowsAffectedParam);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return (int)OutputRowsAffectedParam.Value > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating person.", ex);
            }
        }

        /// <summary>
        /// Deletes a person from the database by their unique identifier.
        /// Executes the "SP_Person_deleteByID" stored procedure.
        /// </summary>
        /// <param name="personID">The unique identifier of the person to delete.</param>
        /// <returns><see langword="true"/> if the person was deleted successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while deleting the person.</exception>
        public static bool DeletePerson(int personID)
        {
            if (personID < 1)
                return false;
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Person_deleteByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", personID);
                        SqlParameter OutputRowsAffectedParam = new SqlParameter()
                        {
                            ParameterName = "@RowsAffected",
                            DbType = DbType.Int32,
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(OutputRowsAffectedParam);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return (int)OutputRowsAffectedParam.Value > 0;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting person.", ex);
            }
        }
    }
}
