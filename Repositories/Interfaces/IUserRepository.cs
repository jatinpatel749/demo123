using Models;
using System;

namespace Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        //  https://www.youtube.com/watch?v=PgqcEoPt-Wc
        //Install-Package AutoMapper
        UserModel ValidateUser(string Email, string Password);
        bool CreateUserNew(UserModel user);

    }
}
