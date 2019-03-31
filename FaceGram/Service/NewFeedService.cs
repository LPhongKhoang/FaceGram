using FaceGram.Common;
using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using FaceGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Service
{
    public class NewFeedService : INewFeedService
    {
        IUserDao userDao;
        IPostDao postDao;
        ICommentDao commentDao;
        IFavoriteDao favoriteDao;
        IRelationshipService relationshipService;
        
        
        public NewFeedService(IUserDao userDao, IPostDao postDao, ICommentDao commentDao, IFavoriteDao favoriteDao, 
            IRelationshipService relationshipService)
        {
            this.userDao = userDao;
            this.postDao = postDao;
            this.commentDao = commentDao;
            this.favoriteDao = favoriteDao;
            this.relationshipService = relationshipService;
            
        }

        public NewFeedModel getNewFeedModel(string id)
        {
            List<PostModel> postModelList = getPostModelsForNewFeed(id);
            List<UserAvatarModel> UnfollowUsers = relationshipService.getSuggestUnFollowUser(id);

            NewFeedModel newFeedModel = new NewFeedModel() { PostModelList = postModelList, UnfollowUsers = UnfollowUsers };
            return newFeedModel;
        }

        public List<PostModel> getPostModelsForNewFeed(string id)
        {
            List<PostModel> postModelList = new List<PostModel>();

            List<User> friends = userDao.getAllFriends(id);
            //loop each friend to get their posts
            foreach(User friend in friends)
            {
                UserAvatarModel userOfPost = new UserAvatarModel() { Id=friend.id, Username=friend.username, Avatar=friend.avatar};
                Post latestPost = postDao.getLatestPostOfUser(friend.id);
                if (latestPost != null)
                {
                    List<CommentModel> top3CommentModels = commentDao.getTop3CommentModels(latestPost.id);
                    int numberOfLikes = favoriteDao.getNumberOfLikesInPost(latestPost.id);
                    string timeAgo = DateTimeUtils.getTimeAgo(latestPost.time.GetValueOrDefault());
                    bool isLike = favoriteDao.isLikeByUser(id, latestPost.id);

                    PostModel postModel = new PostModel()
                    {
                        UserOfPost = userOfPost,
                        PostId = latestPost.id,
                        PostContent = latestPost.content,
                        PostImage = latestPost.image,
                        Top3CommentModels = top3CommentModels,
                        NumberLikes = numberOfLikes,
                        TimeAgo = timeAgo,
                        IsLikeByLoginedUser = isLike
                    };

                    postModelList.Add(postModel);
                }
            }


            return postModelList;
        }
    }
}