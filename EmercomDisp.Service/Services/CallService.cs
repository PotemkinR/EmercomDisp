using EmercomDisp.Service.Contracts.Contracts;
using EmercomDisp.Service.Dto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace EmercomDisp.Service.Services
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
                throw new FaultException<ConnectionFault>(new ConnectionFault(e.Message));
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

                    try
                    {
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
                    catch (SqlException e)
                    {
                        throw new FaultException<SqlFault>(new SqlFault(e.Message));
                    }
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

                    try
                    {
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
                    catch (SqlException e)
                    {
                        throw new FaultException<SqlFault>(new SqlFault(e.Message));
                    }
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
                    cmd.Parameters.AddWithValue("@categoryName", category);

                    try
                    {
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
                    catch (SqlException e)
                    {
                        throw new FaultException<SqlFault>(new SqlFault(e.Message));
                    }
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

                    try
                    {
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
                    catch (SqlException e)
                    {
                        throw new FaultException<SqlFault>(new SqlFault(e.Message));
                    }
                }
            }
            return categoriesList;
        }

        public void UpdateCall(CallDto call)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                connection.Open();

                var transaction = connection.BeginTransaction();
                try
                {
                    var command1 = new SqlCommand("UpdateCall", connection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    
                    command1.Parameters.AddWithValue("@id", call.Id);
                    command1.Parameters.AddWithValue("@address", call.Address);
                    command1.Parameters.AddWithValue("@reason", call.Reason);
                    command1.Parameters.AddWithValue("@callTime", call.CallTime);
                    command1.Parameters.AddWithValue("@category", call.Category);
                    command1.ExecuteNonQuery();

                    var command2 = new SqlCommand("UpdateIncident", connection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };

                    command2.Parameters.AddWithValue("@id", call.Id);
                    command2.Parameters.AddWithValue("@description", call.IncidentDescription);
                    command2.Parameters.AddWithValue("@cause", call.IncidentCause);

                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new FaultException<SqlFault>(new SqlFault(e.Message));
                }
            }
        }

        public void DeleteCall(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("DeleteCall", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException e)
                    {
                        throw new FaultException<SqlFault>(new SqlFault(e.Message));
                    }
                }
            }
        }

        private CallDto GetCallFromDb(SqlDataReader reader)
        {
            var call = new CallDto()
            {
                Id = (int)reader[0],
                Address = reader[1].ToString(),
                Reason = reader[2].ToString(),
                CallTime = (DateTime)reader[3],
                Category = reader[6].ToString(),
                IncidentDescription = reader[8].ToString(),
                IncidentCause = reader[9].ToString()
            };
            return call;
        }
    }
}