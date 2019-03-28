﻿using FaceGram.Database.EF;
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
    }
}
