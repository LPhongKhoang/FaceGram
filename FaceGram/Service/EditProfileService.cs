using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using FaceGram.Models;

namespace FaceGram.Service
{
    public class EditProfileService : IEditProfileService
    {
        private IUserDao userDao;
        private IPostDao postDao;
        private IRelationshipDao relationShipDao;

        public EditProfileService(IUserDao userDao, IPostDao postDao, IRelationshipDao relationShipDao)
        {
            this.userDao = userDao;
            this.postDao = postDao;
            this.relationShipDao = relationShipDao;
        }

        public UserProfileModel getUser(string userID)
        {
            User user = userDao.getUserByID(userID);
            UserProfileModel userProfileModel = new UserProfileModel() {
                   id = user.id,
                   fullname = user.fullname,
                   username = user.username,
                   email = user.email,
                   password = user.password,
                   gender = user.gender,
                   phone_number = user.phone_number,
                   website = user.website,
                   biography = user.biography,
                   avatar = user.avatar
            };

            return userProfileModel;
        }

        public ProfileModel getProfileModel(string userID)
        {
            int numberPostUser = postDao.getNumberPostUser(userID);
            int numberUserFollow = relationShipDao.getNumberUserFollow(userID);
            int numberRelationship = relationShipDao.getNumberRelationship(userID);
            UserProfileModel userProfileModel = getUser(userID);

            ProfileModel profileModel = new ProfileModel()
            {
                NumberPostUser = numberPostUser,
                NumberUserFollow = numberUserFollow,
                NumberRelationship = numberRelationship,
                UserProfileModel = userProfileModel,
            };

            return profileModel;
        }

        public void editUserProfile(UserProfileModel userProfileModel, string uid)
        {
            userDao.editUserProfile(userProfileModel, uid);
        }

    }
}