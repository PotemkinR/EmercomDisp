namespace EmercomDisp.BLL.Services
{
    public interface IUserValidationService
    {
        bool IsValidUser(string name, string password);
    }
}
