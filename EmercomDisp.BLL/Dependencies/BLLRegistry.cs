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
            For<IPasswordEncryptService>().Use<PasswordEncryptService>();
            For<IUserValidationService>().Use<UserValidationService>();
            For<IBrigadeProvider>().Use<BrigadeProvider>();
            For<IVictimsProvider>().Use<VictimsProvider>();
            For<ICallResponseProvider>().Use<CallResponseProvider>();
            For<IEquipmentProvider>().Use<EquipmentProvider>();
            For<ICacheService>().Use<CacheService>();
        }
    }
}
