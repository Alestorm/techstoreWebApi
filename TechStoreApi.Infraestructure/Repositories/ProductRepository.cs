using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStoreApi.Application.Interfaces;
using TechStoreApi.Domain.Models;
using TechStoreApi.Infraestructure.Models;

namespace TechStoreApi.Infraestructure.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Response<int> Create(Product product)
        {
            PRODUCT p = ToData(product);
            Response<int> response = new Response<int>();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("AddProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NAME_VC", p.NAME_VC);
                command.Parameters.AddWithValue("@PRICE_DE", p.PRICE_DE);
                command.Parameters.AddWithValue("@BUILDER_CODE_IN", p.BUILDER_CODE_IN);
                connection.Open();

                response.Data = Convert.ToInt32(command.ExecuteScalar());
                response.State = 201;
                response.Message = "Created";

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

        public Response<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Response<List<Product>> GetAll()
        {
            List<Product> products = new List<Product>();
            Response<List<Product>> response = new Response<List<Product>>();
            PRODUCT product = new PRODUCT();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("ListProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.CODE_IN = reader.GetInt32(0);
                    product.NAME_VC = reader.GetString(1);
                    product.PRICE_DE = reader.GetDecimal(2);
                    product.BUILDER_CODE_IN = reader.GetInt32(3);

                    products.Add(ToProduct(product));
                }
                connection.Close();
                response.Data = products;
                response.State = 200;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.State = 500;
                response.Message = ex.Message;
                response.Exceptions = ex;
            }
            return response;
        }
        private Product ToProduct(PRODUCT pRODUCT)
        {
            return new Product
            {
                Code = pRODUCT.CODE_IN,
                Name = pRODUCT.NAME_VC,
                Price = pRODUCT.PRICE_DE,
                BuilderCode = pRODUCT.BUILDER_CODE_IN
            };
        }
        private PRODUCT ToData(Product product)
        {
            return new PRODUCT
            {
                CODE_IN = product.Code,
                NAME_VC = product.Name,
                PRICE_DE = product.Price,
                BUILDER_CODE_IN = product.BuilderCode
            };
        }
    }
}
