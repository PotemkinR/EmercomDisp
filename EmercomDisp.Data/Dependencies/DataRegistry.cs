using EmercomDisp.Data.Repositories;
using StructureMap;

namespace EmercomDisp.Data.Dependencies
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<ICallRepository>().Use<CallRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<IIncidentRepository>().Use<IncidentRepository>();
            For<IBrigadeRepository>().Use<BrigadeRepository>();
            For<ICallResponseRepository>().Use<CallResponseRepository>();
            For<IVictimsRepository>().Use<VictimsRepository>();
        }
    }
}
