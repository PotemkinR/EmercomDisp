﻿using EmercomDisp.Service.Contracts.Contracts;
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

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            callResponse.Id = (int)reader[0];
                            callResponse.TransferTime = (DateTime)reader[1];
                            callResponse.ArriveTime = (DateTime)reader[2];
                            callResponse.FinishTime = (DateTime)reader[3];
                            callResponse.ReturnTime = (DateTime)reader[4];
                            callResponse.IncidentId = (int)reader[5];
                            callResponse.BrigadeName = reader[6].ToString();
                        }
                    };
                    connection.Close();
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

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var callResponse = new CallResponseDto()
                            {
                                Id = (int)reader[0],
                                TransferTime = (DateTime)reader[3],
                                ArriveTime = (DateTime)reader[4],
                                FinishTime = (DateTime)reader[5],
                                ReturnTime = (DateTime)reader[6],
                                BrigadeName = reader[8].ToString()
                            };
                            callResponseList.Add(callResponse);
                        }
                    };
                    connection.Close();
                }           
            }

            return callResponseList;
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

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    connection.Close();
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

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}