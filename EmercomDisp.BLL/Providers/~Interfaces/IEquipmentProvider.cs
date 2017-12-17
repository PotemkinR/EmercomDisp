using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface IEquipmentProvider
    {
        IEnumerable<Equipment> GetEquipment();
        IEnumerable<Equipment> GetEquipmentByCallResponseId(int id);
        Equipment GetEquipmentById(int id);
        void UpdateEquipmentList(IEnumerable<Equipment> equipment, int callResponseId);
        void CreateEquipment(Equipment equipment);
        void UpdateEquipment(Equipment equipment);
        void DeleteEquipment(int id);
    }
}
