using EruMobileScooter.Data;

namespace EruMobileScooter.Service.Repositories.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Gender GetGender(string id);
        Role GetRole(string id);
        /**
        * Verilen Id ile see user ın aynı olup olmadıgı
        */
        bool Verify(string id, User user);
    }
}