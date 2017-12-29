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
    public class BrigadeService : IBrigadeService
    {
        private readonly string _connectionString;

        public BrigadeService()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["EmercomBase"].ConnectionString;
            }
            catch (ConfigurationErrorsException e)
            {
                throw new FaultException<ConnectionFault>(new ConnectionFault(e.Message), "Unable to connect to the database");
            }
        }

        public BrigadeDto GetBrigadeById(int id)
        {
            var brigade = new BrigadeDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("GetBrigadeById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                brigade.Id = (int)reader[0];
                                brigade.Name = reader[1].ToString();
                                brigade.IsOnCall = (bool)reader[2];
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
            return brigade;
        }

        public IEnumerable<BrigadeMemberDto> GetBrigadeMembers()
        {
            var brigadeMembersList = new List<BrigadeMemberDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetBrigadeMembers", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var brigadeMember = new BrigadeMemberDto()
                                {
                                    Name = reader[1].ToString(),
                                    Id = (int)reader[0]
                                };
                                if (!reader.IsDBNull(4))
                                {
                                    brigadeMember.BrigadeName = reader[4].ToString();
                                }
                                brigadeMembersList.Add(brigadeMember);
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
            return brigadeMembersList;
        }

        public IEnumerable<BrigadeDto> GetBrigades()
        {
            var brigadeList = new List<BrigadeDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetBrigades", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var brigade = new BrigadeDto()
                                {
                                    Name = reader[1].ToString(),
                                    IsOnCall = (bool)reader[2],
                                    MemberCount = (int)reader[3],
                                    Id = (int)reader[0]
                                };
                                brigadeList.Add(brigade);
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
            return brigadeList;
        }

        public IEnumerable<BrigadeMemberDto> GetBrigadeMembersByBrigadeId(int id)
        {
            var brigadeMembersList = new List<BrigadeMemberDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetBrigadeMembersByBrigadeId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var brigadeMember = new BrigadeMemberDto()
                                {
                                    Name = reader[1].ToString(),
                                    Id = (int)reader[0]
                                };
                                brigadeMembersList.Add(brigadeMember);
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
            return brigadeMembersList;
        }

        public void UpdateBrigade(BrigadeDto brigade)
        {
            if (brigade.Name == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Brigade Name"), "Name cannot be null");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("UpdateBrigade", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", brigade.Id);
                    cmd.Parameters.AddWithValue("@name", brigade.Name);

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

        public void CreateBrigade(BrigadeDto brigade)
        {
            if (brigade.Name == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Brigade Name"), "Name cannot be null");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("CreateBrigade", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", brigade.Name);

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

        public void DeleteBrigade(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("DeleteBrigade", connection))
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

        public BrigadeMemberDto GetBrigadeMemberById(int id)
        {
            var brigadeMember = new BrigadeMemberDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("GetBrigadeMemberById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                brigadeMember.Id = (int)reader[0];
                                brigadeMember.Name = reader[1].ToString();
                                if (!reader.IsDBNull(2))
                                {
                                    brigadeMember.BrigadeName = reader[2].ToString();
                                }
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
            return brigadeMember;
        }

        public void UpdateBrigadeMember(BrigadeMemberDto brigadeMember)
        {
            if (brigadeMember.Name == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("BrigadeMember Name"), "Name cannot be null");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("UpdateBrigadeMember", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", brigadeMember.Id);
                    cmd.Parameters.AddWithValue("@name", brigadeMember.Name);
                    if (brigadeMember.BrigadeName != null)
                    {
                        cmd.Parameters.AddWithValue("@brigadeName", brigadeMember.BrigadeName);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@brigadeName", DBNull.Value);
                    }
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

        public void DeleteBrigadeMember(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("DeleteBrigadeMember", connection))
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

        public void CreateBrigadeMember(BrigadeMemberDto brigadeMember)
        {
            if (brigadeMember.Name == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("BrigadeMember Name"), "Name cannot be null");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("CreateBrigadeMember", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", brigadeMember.Name);
                    if (brigadeMember.BrigadeName != null)
                    {
                        cmd.Parameters.AddWithValue("@brigadeName", brigadeMember.BrigadeName);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@brigadeName", DBNull.Value);
                    }
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
    }
}