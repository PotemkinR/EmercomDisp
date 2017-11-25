using EmercomDisp.BLL.Providers;
using StructureMap;

namespace EmercomDisp.BLL.Dependencies
{
    public class BLLRegistry : Registry
    {
        public BLLRegistry()
        {
            For<ICallProvider>().Use<CallProvider>();
        }
    }
}
