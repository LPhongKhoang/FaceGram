using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.Dao;

namespace FaceGram.Service
{
    public class ProfileService : IProfileService
    {
        private IUserDao userDao;

        public ProfileService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

    }
}