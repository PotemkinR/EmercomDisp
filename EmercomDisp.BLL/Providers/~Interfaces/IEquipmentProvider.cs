using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface IEquipmentProvider
    {
        IEnumerable<Equipment> GetEquipment();
        Equipment GetEquipmentById(int id);
        void CreateEquipment(Equipment equipment);
        void UpdateEquipment(Equipment equipment);
        void DeleteEquipment(int id);
    }
}
