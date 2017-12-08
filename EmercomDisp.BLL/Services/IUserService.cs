namespace EmercomDisp.BLL.Services
{
    public interface IUserService
    {
        byte[] EncryptPassword(string password);
    }
}
