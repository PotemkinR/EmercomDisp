using EmercomDisp.Model.Models;

namespace EmercomDisp.Data.Clients
{
    public interface IIncidentClient
    {
        Incident GetIncidentById(int id);
    }
}
