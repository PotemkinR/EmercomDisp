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
    public class CallResponseService : ICallResponseService
    {
        private readonly string _connectionString;

        public CallResponseService()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["EmercomBase"].ConnectionString;
            }
            catch (ConfigurationErrorsException e)
            {
                throw new FaultException<ConnectionFault>(new ConnectionFault(e.Message));
            }
        }

        public CallResponseDto GetCallResponseById(int id)
        {
            var callResponse = new CallResponseDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("GetCallResponseById", connection))
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
                                callResponse.Id = (int)reader[0];
                                callResponse.TransferTime = (DateTime)reader[1];
                                callResponse.ArriveTime = reader[2] as DateTime?;
                                callResponse.FinishTime = reader[3] as DateTime?;
                                callResponse.ReturnTime = reader[4] as DateTime?;
                                callResponse.IncidentId = (int)reader[5];
                                callResponse.BrigadeName = reader[6].ToString();
                                callResponse.IsActive = (bool)reader[7];
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
            return callResponse;
        }

        public IEnumerable<CallResponseDto> GetCallResponsesForCall(int callId)
        {
            var callResponseList = new List<CallResponseDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("GetCallResponsesForCall", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callId", callId);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var callResponse = new CallResponseDto()
                                {
                                    Id = (int)reader[0],
                                    TransferTime = (DateTime)reader[3],
                                    ArriveTime = reader[4] as DateTime?,
                                    FinishTime = reader[5] as DateTime?,
                                    ReturnTime = reader[6] as DateTime?,
                                    IsActive = (bool)reader[7],
                                    BrigadeName = reader[9].ToString()
                                };
                                callResponseList.Add(callResponse);
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

            return callResponseList;
        }     

        public void CreateCallResponse(CallResponseDto callResponse)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("CreateCallResponse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@incidentId", callResponse.IncidentId);
                    cmd.Parameters.AddWithValue("@transferTime", callResponse.TransferTime);
                    cmd.Parameters.AddWithValue("@brigadeName", callResponse.BrigadeName);

                    //try
                    //{
                        connection.Open();

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    //}
                    //catch (SqlException e)
                    //{
                    //    throw new FaultException<SqlFault>(new SqlFault(e.Message));
                    //}
                }
            }
        }

        public void UpdateCallResponse(CallResponseDto callResponse)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("UpdateCallResponse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", callResponse.Id);
                    cmd.Parameters.AddWithValue("@transferTime", callResponse.TransferTime);
                    cmd.Parameters.AddWithValue("@arriveTime", callResponse.ArriveTime);
                    cmd.Parameters.AddWithValue("@finishTime", callResponse.FinishTime);
                    cmd.Parameters.AddWithValue("@returnTime", callResponse.ReturnTime);
                    cmd.Parameters.AddWithValue("@brigadeName", callResponse.BrigadeName);

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

        public void DeleteCallResponse(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("DeleteCallResponse", connection))
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
    }
}