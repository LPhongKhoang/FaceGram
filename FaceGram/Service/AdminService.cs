using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using FaceGram.Models;

namespace FaceGram.Service
{
    public class AdminService : IAdminService
    {
        private IUserDao userDao;
        private IPostDao postDao;
        private IRelationshipDao relationShipDao;

        public AdminService(IUserDao userDao, IPostDao postDao, IRelationshipDao relationShipDao)
        {
            this.userDao = userDao;
            this.postDao = postDao;
            this.relationShipDao = relationShipDao;
        }

        public UserProfileModel getUser(string userID)
        {
            User user = userDao.getUserByID(userID);
            UserProfileModel userProfileModel = new UserProfileModel()
            {
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


        public AdminModel getProfileModel(string userID, string linkClicked)
        {
            UserProfileModel userProfileModel = getUser(userID);

            AdminModel profileModel = new AdminModel()
            {
                UserProfileModel = userProfileModel,
                linkClick = linkClicked
            };

            return profileModel;
        }

    }
}