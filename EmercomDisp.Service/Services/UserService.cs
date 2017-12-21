using EmercomDisp.Service.Contracts.Contracts;
using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace EmercomDisp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;

        public UserService()
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

        public void CreateUser(UserDto user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {


                    using (var cmd = new SqlCommand("CreateUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;

                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var item in user.Roles)
                    {
                        using (var cmd = new SqlCommand("AddUserRole", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@role", item);
                            cmd.Parameters.AddWithValue("@userName", user.Name);
                            cmd.ExecuteNonQuery();
                        }
                    }

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

        public void UpdateUser(UserDto user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {                  
                    using (var command = new SqlCommand("DeleteUserRoles", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = transaction;                   

                        command.Parameters.AddWithValue("@name", null);//
                        command.ExecuteNonQuery();
                    }

                    foreach (var item in user.Roles)
                    {
                        using (var command = new SqlCommand("AddUserRole", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Transaction = transaction;

                            command.Parameters.AddWithValue("@role", item);
                            command.Parameters.AddWithValue("@userName", user.Name);
                            command.ExecuteNonQuery();
                        }
                    }

                    using (var command = new SqlCommand("UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = transaction;

                        command.Parameters.AddWithValue("@name", user.Name);
                        command.Parameters.AddWithValue("@email", user.Email);
                        command.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
                        command.ExecuteNonQuery();
                    }

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

        public void DeleteUser(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("DeleteUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);

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

        public IEnumerable<string> GetRoles()
        {
            var roles = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetRoles", connection))
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

                                roles.Add(category);
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
            return roles;
        }

        public UserDto GetUserByName(string name)
        {
            var user = new UserDto
            {
                Roles = new List<string>()
            };
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                connection.Open();
                var transaction = connection.BeginTransaction();              

                try
                {
                    using (var cmd = new SqlCommand("GetUserByName", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@name", name);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Name = reader[1].ToString();
                                user.PasswordHash = (byte[])reader[2];
                                user.Email = reader[3].ToString();
                            }
                        };
                    }

                    using (var cmd = new SqlCommand("GetUserRoles", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@name", name);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var role = reader[0].ToString();
                                user.Roles.Add(role);
                            }
                        };
                    }
                    transaction.Commit();
                    connection.Close();
                }
                catch(SqlException e)
                {
                    transaction.Rollback();
                    throw new FaultException<SqlFault>(new SqlFault(e.Message));
                }
            }
            return user;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var userList = new List<UserDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetUsers", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new UserDto()
                                {
                                    Name = reader[1].ToString(),
                                    Email = reader[3].ToString()
                                };
                                userList.Add(user);
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
            return userList;
        }   
    }
}