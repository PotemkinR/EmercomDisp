using EmercomDisp.Model.Models;

namespace EmercomDisp.BLL.Providers
{
    public interface IIncidentProvider
    {
        Incident GetIncidentById(int id);
    }
}
