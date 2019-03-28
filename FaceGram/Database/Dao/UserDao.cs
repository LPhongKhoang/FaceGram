using FaceGram.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Database.Dao
{
    public class UserDao : IUserDao
    {
        FaceGramDbContext dbContext;

        public UserDao(FaceGramDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // return user id
        public string insert(User user)
        {
            dbContext.Users.Add(user);
            
            dbContext.SaveChanges();

            return user.id;
        }

    }
}