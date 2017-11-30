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
        private SqlConnection _connection = new SqlConnection();
        private readonly string _connectionString;

        public CallService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EmercomBase"].ConnectionString
            ?? throw new SomethingWrongException("Connection error");
        }

        public CallDto GetCallById(int id)
        {
            _connection.ConnectionString = _connectionString;
            var call = new CallDto();

            using (var cmd = new SqlCommand("GetCallById", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        call = GetCallFromDb(reader);
                    }
                };
                _connection.Close();
            }
            return call;
        }

        public IEnumerable<CallDto> GetCalls()
        {
            _connection.ConnectionString = _connectionString;
            var callList = new List<CallDto>();

            using (var cmd = new SqlCommand("GetCalls", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var call = GetCallFromDb(reader);
                        callList.Add(call);
                    }
                };
                _connection.Close();
            }
            return callList;
        }

        public IEnumerable<CallDto> GetCallsByCategory(string category)
        {
            _connection.ConnectionString = _connectionString;
            var callList = new List<CallDto>();
            using (var cmd = new SqlCommand("GetCallsByCategory", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", category);

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var call = GetCallFromDb(reader);
                        callList.Add(call);
                    }
                };
                _connection.Close();
            }
            return callList;
        }

        public IEnumerable<string> GetCategories()
        {
            _connection.ConnectionString = _connectionString;
            var categoriesList = new List<string>();

            using (var cmd = new SqlCommand("GetCategories", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = reader["Name"].ToString();

                        categoriesList.Add(category);
                    }
                };
                _connection.Close();
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
                TransferTime = (DateTime)reader[4],
                ArriveTime = (DateTime)reader[5],
                FinishTime = (DateTime)reader[6],
                ReturnTime = (DateTime)reader[7],
                Category = reader[12].ToString(),
                BrigadeId = (int)reader[9],
                IncidentId = (int)reader[10]
            };
            return call;
        }
    }
}