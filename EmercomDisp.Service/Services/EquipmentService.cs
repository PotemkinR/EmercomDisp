using EmercomDisp.Service.Contracts.Contracts;
using EmercomDisp.Service.Dto.Models;
using log4net;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace EmercomDisp.Service.Services
{
    public class EquipmentService:IEquipmentService
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");
        private readonly string _connectionString;

        public EquipmentService()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["EmercomBase"].ConnectionString;
            }
            catch (ConfigurationErrorsException e)
            {
                _log.Error(e.Message);
                throw new FaultException<ConnectionFault>(new ConnectionFault(e.Message), "Unable to connect to the database");
            }
        }

        public IEnumerable<EquipmentDto> GetEquipment()
        {
            var equipmentList = new List<EquipmentDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetEquipment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var equipmentItem = new EquipmentDto()
                                {
                                    Id = (int)reader[0],
                                    Name = reader[1].ToString()
                                };
                                equipmentList.Add(equipmentItem);
                            }
                        };
                        connection.Close();
                    }
                    catch (SqlException e)
                    {
                        _log.Error(e.Message);
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
            return equipmentList;
        }

        public IEnumerable<EquipmentDto> GetEquipmentByCallResponseId(int id)
        {
            var equipmentList = new List<EquipmentDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetEquipmentByCallResponseId", connection))
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
                                var equipmentItem = new EquipmentDto()
                                {
                                    Id = (int)reader[0],
                                    Name = reader[1].ToString()
                                };
                                equipmentList.Add(equipmentItem);
                            }
                        };
                        connection.Close();
                    }
                    catch (SqlException e)
                    {
                        _log.Error(e.Message);
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
            return equipmentList;
        }

        public void UpdateEquipmentList(IEnumerable<EquipmentDto> equipment, int callResponseId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                connection.Open();

                var transaction = connection.BeginTransaction();
                try
                {
                    var command1 = new SqlCommand("DeleteEquipmentByCallResponseId", connection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };

                    command1.Parameters.AddWithValue("@id", callResponseId);
                    command1.ExecuteNonQuery();

                    foreach (var item in equipment)
                    {
                        var command = new SqlCommand("AddEquipmentByCallResponseId", connection)
                        {
                            CommandType = CommandType.StoredProcedure,
                            Transaction = transaction
                        };
                        command.Parameters.AddWithValue("@id", item.Id);
                        command.Parameters.AddWithValue("@callResponseId", callResponseId);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    _log.Error(e.Message);
                    throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                }
            }
        }

        public EquipmentDto GetEquipmentById(int id)
        {
            var equipment = new EquipmentDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("GetEquipmentById", connection))
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
                                equipment.Id = (int)reader[0];
                                equipment.Name = reader[1].ToString();
                            }
                        };
                        connection.Close();
                    }
                    catch (SqlException e)
                    {
                        _log.Error(e.Message);
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
            return equipment;
        }

        public void CreateEquipment(EquipmentDto equipment)
        {
            if (equipment.Name == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Equipment Name"), "Name cannot be null");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("CreateEquipment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", equipment.Name);

                    try
                    {
                        connection.Open();

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException e)
                    {
                        _log.Error(e.Message);
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
        }

        public void UpdateEquipment(EquipmentDto equipment)
        {
            if (equipment.Name == null)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault("Equipment Name"), "Name cannot be null");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("UpdateEquipment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", equipment.Id);
                    cmd.Parameters.AddWithValue("@name", equipment.Name);

                    try
                    {
                        connection.Open();

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException e)
                    {
                        _log.Error(e.Message);
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
        }

        public void DeleteEquipment(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ConnectionString = _connectionString;

                using (var cmd = new SqlCommand("DeleteEquipment", connection))
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
                        _log.Error(e.Message);
                        throw new FaultException<SqlFault>(new SqlFault(e.Message), "Database error");
                    }
                }
            }
        }
    }
}