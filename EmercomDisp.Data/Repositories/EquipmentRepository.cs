using EmercomDisp.Data.EquipmentService;
using EmercomDisp.Model.Models;
using log4net;
using System;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public IEnumerable<Equipment> GetEquipment()
        {
            var equipmentList = new List<Equipment>();
            using (var client = new EquipmentServiceClient())
            {
                try
                {
                    client.Open();
                    var equipmentListDto = client.GetEquipment();
                    if (equipmentListDto != null)
                    {
                        foreach (var equipmentItemDto in equipmentListDto)
                        {
                            var equipmentItem = new Equipment()
                            {
                                Id = equipmentItemDto.Id,
                                Name = equipmentItemDto.Name
                            };
                            equipmentList.Add(equipmentItem);
                        }
                    }
                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
            return equipmentList;
        }

        public IEnumerable<Equipment> GetEquipmentByCallResponseId(int id)
        {
            var equipmentList = new List<Equipment>();
            using (var client = new EquipmentServiceClient())
            {
                try
                {
                    client.Open();
                    var equipmentListDto = client.GetEquipmentByCallResponseId(id);
                    if (equipmentListDto != null)
                    {
                        foreach (var equipmentItemDto in equipmentListDto)
                        {
                            var equipmentItem = new Equipment()
                            {
                                Id = equipmentItemDto.Id,
                                Name = equipmentItemDto.Name
                            };
                            equipmentList.Add(equipmentItem);
                        }
                    }
                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
            return equipmentList;
        }

        public void UpdateEquipmentList(IEnumerable<Equipment> equipment, int callResponseId)
        {
            using (var client = new EquipmentServiceClient())
            {
                try
                {
                    client.Open();
                    var equipmentListDto = new List<EquipmentDto>();
                    foreach (var item in equipment)
                    {
                        var itemDto = new EquipmentDto()
                        {
                            Id = item.Id,
                            Name = item.Name
                        };
                        equipmentListDto.Add(itemDto);
                    }

                    client.UpdateEquipmentList(equipmentListDto.ToArray(), callResponseId);

                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public Equipment GetEquipmentById(int id)
        {
            var equipment = new Equipment();
            using (var client = new EquipmentServiceClient())
            {
                try
                {
                    client.Open();

                    var equipmentDto = client.GetEquipmentById(id);

                    if (equipmentDto != null)
                    {
                        equipment.Id = equipmentDto.Id;
                        equipment.Name = equipmentDto.Name;
                    }
                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
            return equipment;
        }

        public void CreateEquipment(Equipment equipment)
        {
            using (var client = new EquipmentServiceClient())
            {
                try
                {
                    client.Open();

                    var newEquipmentItem = new EquipmentDto()
                    {
                        Name = equipment.Name
                    };

                    client.CreateEquipment(newEquipmentItem);

                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void UpdateEquipment(Equipment equipment)
        {
            using (var client = new EquipmentServiceClient())
            {
                try
                {
                    client.Open();

                    var updatedEquipment = new EquipmentDto()
                    {
                        Id = equipment.Id,
                        Name = equipment.Name
                    };

                    client.UpdateEquipment(updatedEquipment);

                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void DeleteEquipment(int id)
        {
            using (var client = new EquipmentServiceClient())
            {
                try
                {
                    client.Open();

                    client.DeleteEquipment(id);

                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
        }
    }
}
