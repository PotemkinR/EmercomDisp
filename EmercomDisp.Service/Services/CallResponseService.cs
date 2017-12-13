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
    }
}