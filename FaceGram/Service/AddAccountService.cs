using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.Dao;
using FaceGram.Database.EF;

namespace FaceGram.Service
{
    public class AddAccountService : IAddAccountService
    {
        private IUserDao userDao;


        public AddAccountService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public void insertAccount(User u)
        {
            userDao.insert(u);
        }

        public void insertRole(Role role)
        {
            userDao.insertRole(role);
        }

        public bool emailExisted(string email)
        {
            List<User> listUser = userDao.getListUser();

            foreach (User u in listUser)
            {
                if (email.ToLower().Equals(u.email.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

        public bool phonelExisted(string phone)
        {
            List<User> listUser = userDao.getListUser();

            foreach (User u in listUser)
            {
                if (phone.Equals(u.phone_number))
                {
                    return false;
                }
            }
            return true;
        }
    }
}