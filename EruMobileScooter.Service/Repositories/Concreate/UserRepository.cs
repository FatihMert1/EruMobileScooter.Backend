using System;
using EruMobileScooter.Data;
using EruMobileScooter.Service.Repositories.Abstract;

namespace EruMobileScooter.Service.Repositories.Concreate
{
    public class UserRepository :  BaseRepository<User>,IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) : base(context)
        {
            if(context == null)
                throw new ArgumentNullException("ApplicationContext Instance Can Not Be Null");
            else
                _context = context;
        }

        public Gender GetGender( string id)
        {
            if(id.Trim().Equals(""))   throw new ArgumentException("Id Can Not Be Empty");
            var user = _context.Users.Find(id);
            if(user != null)
                return user.Gender;
            else
                return Gender.NONE;
        }

        public Role GetRole(string id)
        {
            if(id.Trim().Equals("")) throw new ArgumentException("Id Can Not Be Empty");
            var user = _context.Users.Find(id);
            if(user != null)
                return user.Role;
            else
                return Role.NONE;
        }

        /**
        * Verifying user object and userId.
        */
        public bool Verify(string id, User user)
        {
            if(id.Trim().Equals(""))    throw new ArgumentException("Id Can Not Be Empty");
            if(user == null)    throw new ArgumentNullException("User Can Not Be Null");
            var remoteUser = Get(id);
            if(remoteUser != null){
                return user.Equals(remoteUser);
            }
            return false;
        }
    }
}