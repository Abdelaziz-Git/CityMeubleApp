using Microsoft.Data.SqlClient;
using System.Data;
using TailorSoft_Models;
using TailorSoft_Data_Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace TailorSoft_Data_Layer
{
    /// <summary>
    /// Provides data access methods for managing products in the database.
    /// </summary>
    public class clsProductData
    {
        private readonly AppDbContext _context;

        public clsProductData(AppDbContext context)
        {
            _context = context;
        }


        public static int? AddNewProduct(clsProductDTO productDTO)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (var cmd = new SqlCommand("SP_Product_AddNew", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        _SetCommandParameters(cmd, productDTO);
                        SqlParameter outputIdParam = new SqlParameter("@NewProductID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        object obj = cmd.Parameters["@NewProductID"].Value;
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
                throw new Exception("Error adding new product", ex);
            }
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="productID">The unique identifier of the product to retrieve. Must be a positive integer.</param>
        /// <returns>An instance of <see cref="clsProductDTO"/> representing the product if found; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while retrieving the product from the database.</exception>
        public static clsProductDTO? GetProductByID(int productID)
        {
            try
            {
                List<clsProductDTO> productDTOs = ExecuteQuery("SP_Product_GetByID", new SqlParameter("@ProductID", productID)).ToList();
                if (productDTOs.Count > 0)
                    return productDTOs[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by ID", ex);
            }
        }



        /// <summary>
        /// Updates an existing product in the database using the provided <see cref="clsProductDTO"/>.
        /// Executes the "SP_Product_Update" stored procedure.
        /// </summary>
        /// <param name="productDTO">The product data transfer object containing updated product details.</param>
        /// <returns><see langword="true"/> if the product was updated successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while updating the product.</exception>
        public static bool UpdateProduct(clsProductDTO productDTO)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (var cmd = new SqlCommand("SP_Product_Update", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductID", productDTO.Id);
                        _SetCommandParameters(cmd, productDTO);
                        var outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return (int)outputParam.Value > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product", ex);
            }
        }

        /// <summary>
        /// Deletes a product from the database by its unique identifier.
        /// Executes the "SP_Product_DeleteByID" stored procedure.
        /// </summary>
        /// <param name="productID">The unique identifier of the product to delete.</param>
        /// <returns><see langword="true"/> if the product was deleted successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while deleting the product.</exception>
        public static bool DeleteProduct(int productID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Product_DeleteByID", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductID", productID);
                        SqlParameter OutputRowsAffectedParam = new SqlParameter
                        {
                            ParameterName = "@RowsAffected",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Output
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
                throw new Exception(ex.Message, ex);
            }
        }

        #region Async CRUD Operations
        public static async Task<int?> AddNewProductAsync(clsProductDTO productDTO)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_AddNew", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    _SetCommandParameters(cmd, productDTO);

                    var outputIdParam = new SqlParameter("@NewProductID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return outputIdParam.Value != DBNull.Value ? (int)outputIdParam.Value : null;
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding new product", ex);
            }
        }

        public static async Task<clsProductDTO?> GetProductByIdAsync(int productID)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_GetByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {
                        return await reader.ReadAsync()
                            ? _MapReaderToProductDTO(reader)
                            : null;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by ID", ex);
            }
        }
        public static bool IsProductExistByID(int ProductID)
        {
            using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
            {
                using (var cmd = new SqlCommand("SP_Product_IsExistByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    conn.Open();
                    return (bool)cmd.ExecuteScalar();
                }
            }
        }
        #endregion

        #region Async Get Methods
        public static async Task<List<clsProductDTO>> GetAllActiveProductsAsync(CancellationToken token)
        {
            return await ExecuteProductListQueryAsync("SP_Product_GetAllActive", token);
        }

        public static async Task<List<clsProductDTO>> GetProductsByProductTypeIdAsync(byte productTypeID, CancellationToken token)
        {
            return await ExecuteProductListQueryAsync(
                "SP_Product_GetByTypeID", token,
                new SqlParameter("@ProductTypeID", productTypeID));
        }

        public static async Task<List<clsProductDTO>> GetAllProductsAsync()
        {
            return await ExecuteProductListQueryAsync("SP_Product_GetAll");
        }

        public static async Task<List<clsProductDTO>> GetAllActiveProductsAsync()
        {
            return await ExecuteProductListQueryAsync("SP_Product_GetAllActive");
        }
        public static int GetAllActiveProductsCount()
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_GetAllActiveCount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving active products count", ex);
            }
        }
        public static async Task<List<clsProductDTO>> GetProductsByProductTypeIdAsync(byte productTypeID)
        {
            return await ExecuteProductListQueryAsync(
                "SP_Product_GetByTypeID", parameters: new SqlParameter("@ProductTypeID", productTypeID));
        }
        public static int GetProductsByProductTypeIdCount(byte productTypeID)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_GetByTypeIDCount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeID", productTypeID);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by type ID count", ex);
            }
        }

        public static async Task<List<clsProductDTO>> GetProductsByTypeIdAndCategoryAsync(byte productTypeID, string productCategory)
        {
            return await ExecuteProductListQueryAsync(
                "SP_Product_GetByTypeIdAndCategory",
                new SqlParameter("@ProductTypeID", productTypeID),
                new SqlParameter("@ProductCategory", productCategory));
        }
        public static int GetProductsByTypeIdAndCategoryCount(byte productTypeID, string productCategory)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_GetByTypeIdAndCategoryCount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeID", productTypeID);
                    cmd.Parameters.AddWithValue("@ProductCategory", productCategory);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by type ID and category count", ex);
            }
        }
        public static async Task<List<clsProductDTO>> GetProductsByTypeIdAndColorAsync(byte productTypeID, string productColor)
        {
            return await ExecuteProductListQueryAsync(
                "SP_Product_GetByTypeIdAndColor",
                new SqlParameter("@ProductTypeID", productTypeID),
                new SqlParameter("@ProductColor", productColor)
            );
        }
        public static int GetProductsByTypeIdAndColorCount(byte productTypeID, string productColor)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_GetByTypeIdAndColorCount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeID", productTypeID);
                    cmd.Parameters.AddWithValue("@ProductColor", productColor);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by type ID and color count", ex);
            }
        }

        public static async Task<List<clsProductDTO>> GetProductsByTypeIdAndDimensionsAsync(byte productTypeID, string productDimensions)
        {
            return await ExecuteProductListQueryAsync(
                 "SP_Product_GetByTypeIdAndDimensions",
                 new SqlParameter("@ProductTypeID", productTypeID),
                 new SqlParameter("@ProductDimensions", productDimensions)
             );
        }

        public static async Task<List<clsProductDTO>> GetProductsByCategoryAsync(string productCategory)
        {
            return await ExecuteProductListQueryAsync(
                "SP_Product_GetByCategory",
                new SqlParameter("@ProductCategory", productCategory));
        }

        public static async Task<List<clsProductDTO>> GetProductsByColorAsync(string productColor)
        {
            return await ExecuteProductListQueryAsync(
                "SP_Product_GetByColor",
                new SqlParameter("@ProductColor", productColor));
        }
        #endregion

        #region Async Update/Delete
        public static async Task<bool> UpdateProductAsync(clsProductDTO productDTO, CancellationToken token = default)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productDTO.Id);
                    _SetCommandParameters(cmd, productDTO);

                    var outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    await conn.OpenAsync(token);
                    await cmd.ExecuteNonQueryAsync(token);

                    return (int)outputParam.Value > 0;
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product", ex);
            }
        }

        public static async Task<bool> DeleteProductAsync(int productID, CancellationToken token = default)
        {
            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand("SP_Product_DeleteByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    var outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    await conn.OpenAsync(token);
                    await cmd.ExecuteNonQueryAsync(token);

                    return (int)outputParam.Value > 0;
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product", ex);
            }
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Sets the parameters for a <see cref="SqlCommand"/> using the values from a <see cref="clsProductDTO"/> instance.
        /// </summary>
        /// <param name="cmd">The SQL command to which parameters will be added.</param>
        /// <param name="productDTO">The product data transfer object containing parameter values.</param>
        private static void _SetCommandParameters(SqlCommand cmd, clsProductDTO productDTO)
        {
            cmd.Parameters.AddWithValue("@TypeID", productDTO.TypeID);
            cmd.Parameters.AddWithValue("@Category", productDTO.Category);
            cmd.Parameters.AddWithValue("@Color", productDTO.Color);
            cmd.Parameters.AddWithValue("@Dimensions", productDTO.Dimensions);
            cmd.Parameters.AddWithValue("@Quantity", productDTO.Quantity);
            cmd.Parameters.AddWithValue("@Price", productDTO.Price);
            cmd.Parameters.AddWithValue("@ImagePath", productDTO.ImagePath);
            cmd.Parameters.AddWithValue("@CreatedDate", productDTO.CreatedDate);
            cmd.Parameters.AddWithValue("@LastUpdate", productDTO.LastUpdate);
            cmd.Parameters.AddWithValue("@CreatedByUserID", productDTO.CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsActive", productDTO.IsActive);
        }

        /// <summary>
        /// Maps the current row of a <see cref="SqlDataReader"/> to a <see cref="clsProductDTO"/> instance.
        /// </summary>
        /// <param name="reader">The SQL data reader positioned at a product record.</param>
        /// <returns>A <see cref="clsProductDTO"/> populated with data from the reader.</returns>
        private static clsProductDTO _MapReaderToProductDTO(SqlDataReader reader)
        {
            return new clsProductDTO
            (
                reader.GetInt32(reader.GetOrdinal("ID")),
                reader.GetByte(reader.GetOrdinal("TypeID")),
                reader.GetString(reader.GetOrdinal("Category")),
                reader.GetString(reader.GetOrdinal("Color")),
                reader.GetString(reader.GetOrdinal("Dimensions")),
                reader.GetInt32(reader.GetOrdinal("Quantity")),
                reader.GetDouble(reader.GetOrdinal("Price")),
                reader.GetString(reader.GetOrdinal("ImagePath")),
                reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                reader.GetDateTime(reader.GetOrdinal("LastUpdate")),
                reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                reader.GetBoolean(reader.GetOrdinal("IsActive"))
            );
        }

        private static List<clsProductDTO> ExecuteQuery(string storedProcedureName, params SqlParameter[] parameters)
        {
            List<clsProductDTO> productDTOs = new List<clsProductDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productDTOs.Add(_MapReaderToProductDTO(reader));
                            }
                        }
                    }
                }
                return productDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Adds a new product to the database using the provided <see cref="clsProductDTO"/>.
        /// Executes the "SP_Product_AddNew" stored procedure and returns the newly created ProductID if successful.
        /// </summary>
        /// <param name="productDTO">The product data transfer object containing product details to add.</param>
        /// <returns>The ProductID of the newly added product if successful; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while adding the product.</exception>
        private static async Task<List<clsProductDTO>> ExecuteProductListQueryAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            var products = new List<clsProductDTO>();

            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(_MapReaderToProductDTO(reader));
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing {storedProcedureName}", ex);
            }

            return products;
        }

        private static async Task<List<clsProductDTO>> ExecuteProductListQueryAsync(string storedProcedureName, CancellationToken token, params SqlParameter[] parameters)
        {
            var products = new List<clsProductDTO>();

            try
            {
                using (var conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                using (var cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    await conn.OpenAsync(token);

                    using (var reader = await cmd.ExecuteReaderAsync(token))
                    {
                        while (await reader.ReadAsync(token))
                        {
                            products.Add(_MapReaderToProductDTO(reader));
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SqlException ex) when (token.IsCancellationRequested || ex.Message.Contains("Operation cancelled by user", StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException($"Execution of {storedProcedureName} was cancelled.", ex, token);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing {storedProcedureName}", ex);
            }

            return products;
        }

        #endregion
    }
}
