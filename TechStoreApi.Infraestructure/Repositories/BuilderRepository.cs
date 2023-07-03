using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStoreApi.Domain.Interfaces;
using TechStoreApi.Domain.Models;
using TechStoreApi.Infraestructure.Models;

namespace TechStoreApi.Infraestructure.Repositories
{


    public class BuilderRepository : IBuilderRepository
    {
        private readonly string _connectionString;
        public BuilderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Response<int> Create(Builder builder)
        {
            Response<int> response = new Response<int>();
            BUILDER bUILDER = ToData(builder);
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);

                SqlCommand command = new SqlCommand("AddBuilder", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NAME_VC", bUILDER.NAME_VC);

                connection.Open();

                response.State = 201;
                response.Message = "Created";
                response.Data = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

            }
            catch (SqlException ex)
            {
                response.State = 500;
                response.Message = ex.Message;
                response.Exceptions = ex;
            }
            return response;
        }
        public static BUILDER ToData(Builder builder)
        {
            return new BUILDER
            {
                NAME_VC = builder.Name
            };
        }
    }
}
