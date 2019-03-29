﻿using FaceGram.Database.EF;
using FaceGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Database.Dao
{
    public interface IUserDao
    {
        string insert(User user);

        char isExistUser(string email, string password);

        User getByEmail(string email);

        User getUserByEmailPass(string email, string password);

        string getUserName(string uid);

        User getUserByID(string id);

        List<User> getListUser();

        List<User> getUserExcept(string id);

        void editUserProfile(UserProfileModel userProfileModel, string uid);
    }
}
