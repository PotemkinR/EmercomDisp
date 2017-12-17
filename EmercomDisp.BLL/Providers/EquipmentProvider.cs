using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public class EquipmentProvider : IEquipmentProvider
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentProvider(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository ?? throw new ArgumentNullException("Equipment Repository");
        }

        public IEnumerable<Equipment> GetEquipment()
        {
            return _equipmentRepository.GetEquipment();
        }

        public IEnumerable<Equipment> GetEquipmentByCallResponseId(int id)
        {
            return _equipmentRepository.GetEquipmentByCallResponseId(id);
        }

        public void UpdateEquipmentList(IEnumerable<Equipment> equipment, int callResponseId)
        {
            _equipmentRepository.UpdateEquipmentList(equipment, callResponseId);
        }

        public Equipment GetEquipmentById(int id)
        {
            return _equipmentRepository.GetEquipmentById(id);
        }

        public void CreateEquipment(Equipment equipment)
        {
            _equipmentRepository.CreateEquipment(equipment);
        }

        public void UpdateEquipment(Equipment equipment)
        {
            _equipmentRepository.UpdateEquipment(equipment);
        }

        public void DeleteEquipment(int id)
        {
            _equipmentRepository.DeleteEquipment(id);
        }
    }
}
