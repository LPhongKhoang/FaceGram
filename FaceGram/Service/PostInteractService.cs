using FaceGram.Common;
using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Service
{
    public class PostInteractService : IPostInteractService
    {
        private IFavoriteDao favoriteDao;
        private ICommentDao commentDao;

        public PostInteractService(IFavoriteDao favoriteDao, ICommentDao commentDao)
        {
            this.favoriteDao = favoriteDao;
            this.commentDao = commentDao;
        }

        public bool addComment(string userId, string text, string postId)
        {
            
            Comment newComment = new Comment() { id=DateTimeUtils.getKeyTimeStamp(), uid=userId, post_id=postId, content=text, time=DateTime.Now};
            return commentDao.insertComment(newComment);
           
        }

        public int getNumberLikedOfPost(string postId)
        {
            return favoriteDao.getNumberOfLikesInPost(postId);
        }

        public bool toggleLikeAPost(string userId, string postId)
        {

            return favoriteDao.toggleLikeAPost(userId, postId);
            
        }
    }
}