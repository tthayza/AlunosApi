﻿using System.Threading.Tasks;

namespace AlunosApi.Services
{
    public interface IAuthenticate
    {
        Task<bool> RegisterUser(string email, string password);
        Task <bool> Authenticate(string email, string password);
        Task Logout();
    }
}
