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
                throw new FaultException<ConnectionFault>(new ConnectionFault(e.Message), "Unable to connect to the database");
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
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
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
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
            return callList;
        }

        public IEnumerable<CallDto> GetCallsByCategory(string category)
        {
            if (category == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Category"), "Category cannot be null");
            }

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
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
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
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
            return categoriesList;
        }

        public int CreateCall(CallDto call)
        {
            if (call.Category == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Category"), "Category cannot be null");
            }
            if (call.Address == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Address"), "Address cannot be null");
            }
            if (call.Reason == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Reason"), "Reason cannot be null");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("CreateCall", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@address", call.Address);
                    cmd.Parameters.AddWithValue("@callTime", call.CallTime);
                    cmd.Parameters.AddWithValue("@reason", call.Reason);
                    cmd.Parameters.AddWithValue("@category", call.Category);

                    var returnParameter = cmd.Parameters.Add("@id", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;
                    try
                    {
                        connection.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        connection.Close();

                        return result;
                    }
                    catch (SqlException e)
                    {
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
        }

        public void UpdateCall(CallDto call)
        {
            if (call.Category == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Category"), "Category cannot be null");
            }
            if (call.Address == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Address"), "Address cannot be null");
            }
            if (call.Reason == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Reason"), "Reason cannot be null");
            }
            if (call.IncidentDescription == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Incident Description"), "Incident Description cannot be null");
            }
            if (call.IncidentCause == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Incident Cause"), "Incident Cause");
            }

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
                    throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
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
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
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
                IsActive = (bool)reader[5],
                Category = reader[7].ToString(),
                IncidentDescription = reader[9].ToString(),
                IncidentCause = reader[10].ToString()
            };
            return call;
        }
    }
}