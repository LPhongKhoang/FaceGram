using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using FaceGram.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Service
{
    public class UserService : IUserService
    {
        private IUserDao userDao;
        private IRelationshipService relationshipService;

        public UserService(IUserDao userDao, IRelationshipService relationshipService)
        {
            this.userDao = userDao;
            this.relationshipService = relationshipService;
        }

        public IPagedList<UserAvatarModel> getAllUserExcept(string userId, int page, int pageSize)
        {
            List<UserAvatarModel> userAvatars = new List<UserAvatarModel>();
            IQueryable<User> users = userDao.getUsersExcept(userId);
            foreach(User user in users)
            {
                string relationshipStatus = relationshipService.getRelationship(userId, user.id);
                userAvatars.Add(new UserAvatarModel() { Id=user.id, Avatar=user.avatar,
                    Username =user.username, RelationshipStatus=relationshipStatus});
            }

            return userAvatars.ToPagedList(page, pageSize);
        }

        public User getByEmail(string email)
        {
            return userDao.getByEmail(email);
        }

        public string getRole(string userId)
        {
            return userDao.getRole(userId);
        }

        public IPagedList<UserAvatarModel> searchUserByUserName(string textSearch, string loginedUserId, int page, int pageSize)
        {
            List<UserAvatarModel> userAvatars = new List<UserAvatarModel>();
            IQueryable<User> users = userDao.searchUserByUsername(textSearch, loginedUserId);
            foreach (User user in users)
            {
                string relationshipStatus = relationshipService.getRelationship(loginedUserId, user.id);
                userAvatars.Add(new UserAvatarModel()
                {
                    Id = user.id,
                    Avatar = user.avatar,
                    Username = user.username,
                    RelationshipStatus = relationshipStatus
                });
            }

            return userAvatars.ToPagedList(page, pageSize);
        }

        public char verifyAccount(string email, string password)
        {
            return userDao.isExistUser(email, password);
        }




    }
}