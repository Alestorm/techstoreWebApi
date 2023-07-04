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
        public Response<List<Builder>> GetAll()
        {
            Response<List<Builder>> response = new Response<List<Builder>>();
            List<Builder> list = new List<Builder>();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("ListBuilder", connection);
                connection.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Builder builder = new Builder();
                    builder.Code = reader.GetInt32(0);
                    builder.Name = reader.GetString(1);
                    list.Add(builder);
                }
                connection.Close();
                response.Data = list;
                response.State = 200;
                response.Message = "Ok";
            }
            catch (SqlException ex)
            {
                response.State = 500;
                response.Message = ex.Message;
                response.Exceptions = ex;
            }
            return response;
        }

        public Response<Builder> GetById(int id)
        {
            Response<Builder> response = new Response<Builder>();
            Builder builder = new Builder();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("GetBuilderById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CODE_IN", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    builder.Code = reader.GetInt32(0);
                    builder.Name = reader.GetString(1);

                    response.Data = builder;
                    response.State = 200;
                    response.Message = "Found";
                }
                else
                {
                    response.State = 404;
                    response.Message = "Not found";
                }

            }
            catch (SqlException ex)
            {
                response.State = 500;
                response.Message = ex.Message;
                response.Exceptions = ex;
            }
            return response;
        }
        public Response<Builder> Update(Builder builder)
        {
            Response<Builder> response = new Response<Builder>();
            Builder b = new Builder();
            BUILDER bUILDER = ToData(builder);
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("UpdateBuilder", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CODE_IN", bUILDER.CODE_IN);
                command.Parameters.AddWithValue("@NAME_VC", bUILDER.NAME_VC);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    b.Code = reader.GetInt32(0);
                    b.Name = reader.GetString(1);
                }
                connection.Close();
                response.Data = b;
                response.State = 200;
                response.Message = "Updated";
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
                CODE_IN = builder.Code,
                NAME_VC = builder.Name
            };
        }
    }
}
