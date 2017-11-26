using EmercomDisp.Model.Models;
using EmercomDisp.Service.Contracts.Contracts;
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
        private readonly string _connectionString = ConfigurationManager
            .ConnectionStrings["EmercomBase"].ConnectionString;

        public Call GetCallById(int id)
        {
            _connection.ConnectionString = _connectionString;
            var call = new Call();

            using (var cmd = new SqlCommand("GetCallById", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        call.Id = (int)reader[0];
                        call.Address = reader[1].ToString();
                        call.Reason = reader[2].ToString();
                        call.CallTime = (DateTime)reader[3];
                        call.TransferTime = (DateTime)reader[4];
                        call.ArriveTime = (DateTime)reader[5];
                        call.FinishTime = (DateTime)reader[6];
                        call.ReturnTime = (DateTime)reader[7];
                        call.Category = reader[12].ToString();
                        call.BrigadeId = (int)reader[9];
                        call.IncidentId = (int)reader[10];
                    }
                };
                _connection.Close();
            }
            return call;
        }

        public IEnumerable<Call> GetCalls()
        {
            _connection.ConnectionString = _connectionString;
            var callList = new List<Call>();

            using (var cmd = new SqlCommand("GetCalls", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var call = new Call
                        {
                            Id = (int)reader[0],
                            Address = reader[1].ToString(),
                            Reason = reader[2].ToString(),
                            CallTime = (DateTime)reader[3],
                            TransferTime = (DateTime)reader[4],
                            ArriveTime = (DateTime)reader[5],
                            FinishTime = (DateTime)reader[6],
                            ReturnTime = (DateTime)reader[7],
                            Category = reader[8].ToString(),
                            BrigadeId = (int)reader[9],
                            IncidentId = (int)reader[10]
                        };
                        callList.Add(call);
                    }
                };
                _connection.Close();
            }
            return callList;
        }

        public IEnumerable<Call> GetCallsByCategory(string category)
        {
            _connection.ConnectionString = _connectionString;
            var callList = new List<Call>();

            using (var cmd = new SqlCommand("GetCallsByUrgency", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryId", category);

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var call = new Call
                        {
                            Id = (int)reader[0],
                            Address = reader[1].ToString(),
                            Reason = reader[2].ToString(),
                            CallTime = (DateTime)reader[3],
                            TransferTime = (DateTime)reader[4],
                            ArriveTime = (DateTime)reader[5],
                            FinishTime = (DateTime)reader[6],
                            ReturnTime = (DateTime)reader[7],
                            Category = reader[8].ToString(),
                            BrigadeId = (int)reader[9],
                            IncidentId = (int)reader[10]
                        };
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
    }
}