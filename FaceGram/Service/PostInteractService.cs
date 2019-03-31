using FaceGram.Common;
using FaceGram.Database.Dao;
using FaceGram.Database.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FaceGram.Service
{
    public class PostInteractService : IPostInteractService
    {
        private IFavoriteDao favoriteDao;
        private ICommentDao commentDao;
        private IPostDao postDao;

        public PostInteractService(IFavoriteDao favoriteDao, ICommentDao commentDao, IPostDao postDao)
        {
            this.favoriteDao = favoriteDao;
            this.commentDao = commentDao;
            this.postDao = postDao;
        }

        public bool addComment(string userId, string text, string postId)
        {

            Comment newComment = new Comment() { id = DateTimeUtils.getKeyTimeStamp(), uid = userId, post_id = postId, content = text, time = DateTime.Now };
            return commentDao.insertComment(newComment);

        }

        public string addPost(string userId, string postContent, string imagePath)
        {
            string postId = DateTimeUtils.getKeyTimeStamp();
            Post post = new Post() { id = postId, uid = userId, image = imagePath, time = DateTime.Now, content = postContent };
            bool result = postDao.insert(post);
            if (result)
            {
                return postId;
            }
            else
            {
                return null;
            }
        }

        public int getNumberLikedOfPost(string postId)
        {
            return favoriteDao.getNumberOfLikesInPost(postId);
        }

        public string saveFileToServer(HttpPostedFileWrapper file)
        {
            try
            {
                // Build unique file name
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);

                string hashKey = DateTimeUtils.getKeyTimeStamp();

                // Get folder in server 
                fileName = CommonConstant.IMAGE_ROOT + fileName + hashKey + extension;

                // Get absolute physical path to save image to that location
                string actualPath = HttpRuntime.AppDomainAppPath;
                file.SaveAs(actualPath + fileName);

                return fileName;
            }
            catch
            {
                return null;
            }


        }

        public bool toggleLikeAPost(string userId, string postId)
        {

            return favoriteDao.toggleLikeAPost(userId, postId);

        }
    }
}