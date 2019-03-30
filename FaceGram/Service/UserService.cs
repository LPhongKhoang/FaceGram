using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Service
{
    public class UserService : IUserService
    {
        private IUserDao userDao;

        public UserService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public User getByEmail(string email)
        {
            return userDao.getByEmail(email);
        }

        public string getRole(string userId)
        {
            return userDao.getRole(userId);
        }

        public char verifyAccount(string email, string password)
        {
            return userDao.isExistUser(email, password);
        }




    }
}