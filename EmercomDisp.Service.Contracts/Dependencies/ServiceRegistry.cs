using EmercomDisp.Service.Contracts.Contracts;
using StructureMap;

namespace EmercomDisp.Service.Contracts.Dependencies
{
    public class ServiseRegistry : Registry
    {
        public ServiseRegistry()
        {
            For<ICallService>().Use<FakeCallService>();
        }
    }
}