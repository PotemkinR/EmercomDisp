using System.Collections.Generic;

namespace EmercomDisp.Web.Models.Equipment_
{
    public class EditEquipmentListModel
    {
        public int CallResponseId { get; set; }
        public IList<EquipmentSelectable> Equipment { get; set; }
    }
}