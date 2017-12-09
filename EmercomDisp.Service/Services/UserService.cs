using System.Collections.Generic;
using EmercomDisp.Service.Contracts.Contracts;
using EmercomDisp.Service.Dto.Models;
using System.Configuration;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Data;

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
            var call = new CallDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("CreateUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@email", user.Email);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteUser(string name)
        {
            throw new System.NotImplementedException();
        }

        public UserDto GetUserByName(string name)
        {
            var user = new UserDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("GetUserByName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Name = reader[1].ToString();
                            user.PasswordHash = (byte[])reader[2];
                            user.Email = reader[3].ToString();
                        }
                    };
                    connection.Close();
                }
            }
            return user;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public bool UserIsValid(string name, string passwordHash)
        {
            throw new System.NotImplementedException();
        }
    }
}