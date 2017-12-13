using EmercomDisp.Model.Models;

namespace EmercomDisp.Data.Repositories
{
    public interface IIncidentRepository
    {
        Incident GetIncidentById(int id);
    }
}
