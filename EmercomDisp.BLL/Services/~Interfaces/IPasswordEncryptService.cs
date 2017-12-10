namespace EmercomDisp.BLL.Services
{
    public interface IPasswordEncryptService
    {
        byte[] EncryptPassword(string password);     
    }
}
