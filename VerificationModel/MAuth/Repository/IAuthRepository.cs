﻿using ConstradeApi_Admin.VerificationEntity;

namespace ConstradeApi_Admin.VerificationModel.MAuth.Repository
{
    public interface IAuthRepository
    {
        Task<AdminAccounts> Login(string username, string password);
        Task<bool> Register(string username, string password,string key);
    }
}
