using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using FaceGram.Models;

namespace FaceGram.Service
{
    public class ProfileService : IProfileService
    {
        private IUserDao userDao;
        private IPostDao postDao;
        private IRelationshipDao relationShipDao;
        

        public ProfileService(IUserDao userDao, IPostDao postDao, IRelationshipDao relationShipDao)
        {
            this.userDao = userDao;
            this.postDao = postDao;
            this.relationShipDao = relationShipDao;
        }

        public List<PostProfileModel> getCurrentPost(string userID)
        {
            List<Post> listCurrentPost = postDao.getCurrentUserPost(userID);
            PostProfileModel postProfileModel;
            List<PostProfileModel> listPostProfileModel = new List<PostProfileModel>();
            foreach (Post post in listCurrentPost)
            {
                postProfileModel = new PostProfileModel()
                {
                    id = post.id,
                    uid = post.uid,
                    image = post.image,
                    time = post.time,
                    content = post.content
                };
                listPostProfileModel.Add(postProfileModel);
            }

            return listPostProfileModel;
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

        public ProfileModel getProfileModel(string userID, string loginUserId)
        {
            int numberPostUser = postDao.getNumberPostUser(userID);
            int numberUserFollow = relationShipDao.getNumberUserFollow(userID);
            int numberRelationship = relationShipDao.getNumberRelationship(userID);
            UserProfileModel userProfileModel = getUser(userID);
            string relationshipStatus = relationShipDao.getRelationship(loginUserId, userID);
            userProfileModel.RelationshipStatus = relationshipStatus;

            List<PostProfileModel> listPostProfileModel = getCurrentPost(userID);

            ProfileModel profileModel = new ProfileModel()
            {
                NumberPostUser = numberPostUser,
                NumberUserFollow = numberUserFollow,
                NumberRelationship = numberRelationship,
                UserProfileModel = userProfileModel,
                GetcurrentPost = listPostProfileModel,
            };

            return profileModel;
        }


    }
}