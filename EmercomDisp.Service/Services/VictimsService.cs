﻿using EmercomDisp.Service.Contracts.Contracts;
using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace EmercomDisp.Service.Services
{
    public class VictimsService : IVictimsService
    {
        private readonly string _connectionString;

        public VictimsService()
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

        public VictimDto GetVictimById(int id)
        {
            var victim = new VictimDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("GetVictimById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            victim.Name = reader[1].ToString();
                            victim.Residence = reader[2].ToString();
                            victim.Age = (int)reader[3];
                        }
                    };
                    connection.Close();
                }
            }
            return victim;
        }

        public IEnumerable<VictimDto> GetVictimsByIncidentId(int id)
        {
            var victimsList = new List<VictimDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetVictimsByIncidentId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var victimDto = new VictimDto()
                            {
                                Id = (int)reader[0],
                                Name = reader[1].ToString(),
                                Residence = reader[2].ToString(),
                                Age = (int)reader[3]
                            };
                            victimsList.Add(victimDto);
                        }
                    };
                    connection.Close();
                }
            }
            return victimsList;
        }

        public void AddVictim(VictimDto victim, int callId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("CreateVictim", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", victim.Name);
                    cmd.Parameters.AddWithValue("@residence", victim.Residence);
                    cmd.Parameters.AddWithValue("@age", victim.Age);
                    cmd.Parameters.AddWithValue("@incidentId", callId);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateVictim(VictimDto victim)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("UpdateVictim", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", victim.Id);
                    cmd.Parameters.AddWithValue("@name", victim.Name);
                    cmd.Parameters.AddWithValue("@residence", victim.Residence);
                    cmd.Parameters.AddWithValue("@age", victim.Age);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteVictim(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("DeleteVictim", connection))
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