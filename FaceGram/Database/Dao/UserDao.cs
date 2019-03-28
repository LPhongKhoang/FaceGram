using FaceGram.Common;
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

        public User getByEmail(string email)
        {
            return dbContext.Users.SingleOrDefault(x => x.email == email);
        }

        // return user id
        public string insert(User user)
        {
            dbContext.Users.Add(user);
            
            dbContext.SaveChanges();

            return user.id;
        }

        public char isExistUser(string email, string password)
        {
            int count = dbContext.Users.Count(x => x.email == email && x.password == password);
            if(count == 1)
            {
                return CommonConstant.LOGIN_OK;
            }
            else
            {
                return CommonConstant.LOGIN_FAIL;
            }
        }
    }
}