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
        private ICommentDao commentDao;
        private IFavoriteDao favoriteDao;

        public string linkClicked { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AdminService(IUserDao userDao, IPostDao postDao, IRelationshipDao relationShipDao, ICommentDao commentDao, IFavoriteDao favoriteDao)
        {
            this.userDao = userDao;
            this.postDao = postDao;
            this.relationShipDao = relationShipDao;
            this.commentDao = commentDao;
            this.favoriteDao = favoriteDao;
        }

        public List<UserProfileModel> getAllUser()
        {
            List<User> listAllUser = userDao.getListUser();
            UserProfileModel userProfileModel;
            List<UserProfileModel> listUserProfileModel = new List<UserProfileModel>();

            foreach(User user in listAllUser)
            {
                userProfileModel = new UserProfileModel()
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

                listUserProfileModel.Add(userProfileModel);
            }

            return listUserProfileModel;
        }

        public List<PostProfileModel> getAllPost()
        {
            List<Post> listPost = postDao.getAllPost();
            PostProfileModel postProfileModel;
            List<PostProfileModel> listPostProfileModel = new List<PostProfileModel>();

            foreach (Post p in listPost)
            {
                postProfileModel = new PostProfileModel()
                {
                    id = p.id,
                    uid = p.uid,
                    content = p.content,
                    image = p.image,
                    time = p.time
                };
                listPostProfileModel.Add(postProfileModel);
            }

            return listPostProfileModel;
        }

        public List<CommentModel> allComment()
        {
            List<Comment> listComment = commentDao.getAllComments();
            CommentModel commentModel;
            List<CommentModel> listCommentModel = new List<CommentModel>();

            foreach(Comment cm in listComment)
            {
                commentModel = new CommentModel()
                {
                    id = cm.id,
                    uid = cm.uid,
                    PostId = cm.post_id,
                    Content = cm.content,
                    time = cm.time
                };
                listCommentModel.Add(commentModel);
            }

            return listCommentModel;
        }

        public List<RelationshipModel> allRelationship()
        {
            List<Relationship> listRelationship = relationShipDao.getAllRelationship();
            RelationshipModel relationshipModel;
            List<RelationshipModel> listRelationshipModel = new List<RelationshipModel>();

            foreach (Relationship rl in listRelationship)
            {
                relationshipModel = new RelationshipModel()
                {
                    id = rl.id,
                    fId = rl.fId,
                    uId = rl.uId
                };
                listRelationshipModel.Add(relationshipModel);
            }

            return listRelationshipModel;
        }

        public List<FavoriteModel> allFavorite()
        {
            List<Favorite> listFavorite = favoriteDao.getAllFavorite();
            FavoriteModel favoriteModel;
            List<FavoriteModel> listFavoriteModel = new List<FavoriteModel>();

            foreach (Favorite fvr in listFavorite)
            {
                favoriteModel = new FavoriteModel()
                {
                    id = fvr.id,
                    pId = fvr.pId,
                    uId = fvr.uId
                };
                listFavoriteModel.Add(favoriteModel);
            }

            return listFavoriteModel;
        }


        public AdminModel getAdminModel(string linkClicked)
        {
            List<UserProfileModel> userProfileModel = getAllUser();
            List<PostProfileModel> postProfileModel = getAllPost();
            List<CommentModel> commenModel = allComment();
            List<RelationshipModel> relationshopModel = allRelationship();
            List<FavoriteModel> favoriteModel = allFavorite();

            AdminModel adminModel = new AdminModel()
            {
                listUserProfileModel = userProfileModel,
                listPostProfileModel = postProfileModel,
                listCommentModel = commenModel,
                listRelationshipModel = relationshopModel,
                listFavoriteModel = favoriteModel,
                linkClick = linkClicked
            };

            return adminModel;
        }

        public void deleteComment(string id)
        {
            commentDao.deleteComment(id);
        }

        public void deleteRelationship(string id)
        {
            relationShipDao.deleteRelationshipByID(id);
        }

        public void deleteFavorite(string id)
        {
            favoriteDao.deleteFavorite(id);
        }

    }
}