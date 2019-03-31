using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using FaceGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Service
{
    public class RelationshipService : IRelationshipService
    {
        private IRelationshipDao relationshipDao;
        private IUserDao userDao;
        public RelationshipService(IRelationshipDao relationshipDao, IUserDao userDao)
        {
            this.relationshipDao = relationshipDao;
            this.userDao = userDao;
        }

        public bool toggleFollow(string userId, string friendId)
        {
            return relationshipDao.toggleFollow(userId, friendId);
        }

        public List<UserAvatarModel> getAllUnFollowUser(string userId)
        {
            List<UserAvatarModel> userAvatars = new List<UserAvatarModel>();
            List<User> users = userDao.getAllUnFollowUsers(userId);
            foreach (User user in users)
            {
                string relationshipStatus = getRelationship(userId, user.id);
                UserAvatarModel userAvatar = new UserAvatarModel() { Id = user.id, Avatar = user.avatar,
                    Username = user.username, RelationshipStatus=relationshipStatus };
                userAvatars.Add(userAvatar);
            }

            return userAvatars;
        }

        public List<UserAvatarModel> getSuggestUnFollowUser(string userId)
        {
            List<UserAvatarModel> userAvatars = getAllUnFollowUser(userId).Take(5).ToList();
            return userAvatars;
        }

        public string getRelationship(string userId, string friendId)
        {
            return relationshipDao.getRelationship(userId, friendId);
        }
    }
}