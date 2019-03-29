using FaceGram.Common;
using FaceGram.Database.EF;
using FaceGram.Models;
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


        // return user by email and password
        public User getUserByEmailPass(string email, string password)
        {
            return dbContext.Users.SingleOrDefault(x => x.email.Equals(email) && x.password.Equals(password));
        }

        // return string username
        public string getUserName(string uid)
        {
            var username = dbContext.Users.Where(x => x.id.Equals(uid)).Select(column => column.username);
            return username.ToString();
        }


        // return user by ID
        public User getUserByID(string id)
        {
            return dbContext.Users.SingleOrDefault(x => x.id.Equals(id));
        }

        // return list user
        public List<User> getListUser()
        {
            var listUser = (from a in dbContext.Users
                            join b in dbContext.Roles
                            on a.id equals b.uid
                            select new
                            {
                                User = a,
                                Role = b
                            }).ToList().Select(x => new User
                            {
                                id = x.User.id,
                                fullname = x.User.fullname,
                                username = x.User.username,
                                email = x.User.email,
                                password = x.User.password,
                                gender = x.User.gender,
                                phone_number = x.User.phone_number,
                                website = x.User.website,
                                biography = x.User.biography,
                                avatar = x.User.avatar,
                                Role = new Role()
                                {
                                    role1 = x.Role.role1
                                }
                            });

            return listUser.ToList();
        }

        // return get list user except
        public List<User> getUserExcept(string id)
        {
            var listUserExcept = dbContext.Users.Where(x => !x.id.Equals(id));
            return listUserExcept.ToList();
        }

        // edit user profile
        public void editUserProfile(UserProfileModel userProfileModel, string uid)
        {
            User user = dbContext.Users.Single(c => c.id.Equals(uid));

            user.fullname = userProfileModel.fullname;
            user.username = userProfileModel.username;
            user.website = userProfileModel.website;
            user.biography = userProfileModel.biography;
            user.phone_number = userProfileModel.phone_number;

            dbContext.SaveChanges();
        }
    }
}