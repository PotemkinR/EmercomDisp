using EmercomDisp.BLL.Providers;
using EmercomDisp.BLL.Services;
using StructureMap;

namespace EmercomDisp.BLL.Dependencies
{
    public class BLLRegistry : Registry
    {
        public BLLRegistry()
        {
            For<ICallProvider>().Use<CallProvider>();
            For<IUserProvider>().Use<UserProvider>();
            For<ILoginService>().Use<LoginService>();
            For<IUserService>().Use<UserService>();
        }
    }
}
