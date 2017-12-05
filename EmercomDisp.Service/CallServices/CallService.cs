using EmercomDisp.Service.Contracts.Contracts;
using EmercomDisp.Service.Dto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmercomDisp.Service.CallServices
{
    public class CallService : ICallService
    {
        private readonly string _connectionString;

        public CallService()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["EmercomBase"].ConnectionString;               
            }
            catch(ConfigurationErrorsException e)
            {
                throw new SomethingWrongException(e.Message);
            }
        }

        public CallDto GetCallById(int id)
        {
            var call = new CallDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;
                
                using (var cmd = new SqlCommand("GetCallById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            call = GetCallFromDb(reader);
                        }
                    };
                    connection.Close();
                }
            }
            return call;
        }

        public IEnumerable<CallDto> GetCalls()
        {
            var callList = new List<CallDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetCalls", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var call = GetCallFromDb(reader);
                            callList.Add(call);
                        }
                    };
                    connection.Close();
                }
            }
            return callList;
        }

        public IEnumerable<CallDto> GetCallsByCategory(string category)
        {
            var callList = new List<CallDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetCallsByCategory", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryName", category);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var call = GetCallFromDb(reader);
                            callList.Add(call);
                        }
                    };
                    connection.Close();
                }
            }
            return callList;
        }

        public IEnumerable<string> GetCategories()
        {
            var categoriesList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetCategories", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = reader["Name"].ToString();

                            categoriesList.Add(category);
                        }
                    };
                    connection.Close();
                }
            }
            return categoriesList;
        }

        private CallDto GetCallFromDb(SqlDataReader reader)
        {
            var call = new CallDto()
            {
                Id = (int)reader[0],
                Address = reader[1].ToString(),
                Reason = reader[2].ToString(),
                CallTime = (DateTime)reader[3],
                Category = reader[6].ToString()
            };
            return call;
        }
    }
}