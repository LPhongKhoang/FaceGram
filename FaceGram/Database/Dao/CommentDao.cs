using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.EF;
using FaceGram.Models;

namespace FaceGram.Database.Dao
{
    public class CommentDao : ICommentDao
    {
        private FaceGramDbContext dbContext;

        public CommentDao(FaceGramDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CommentModel> getTop3CommentModels(string postId)
        {
            var comments = (from comment in dbContext.Comments
                            join user in dbContext.Users
                            on comment.uid equals user.id
                            where comment.post_id == postId
                            orderby comment.time descending
                            select new CommentModel()
                            {
                                PostId = comment.post_id,
                                UserOfComment = new UserAvatarModel()
                                {
                                    Id =  user.id,
                                    Username = user.username,
                                    Avatar = user.avatar
                                },
                                Content = comment.content
                            }).Take(3);

            return comments.ToList();
        }

        public bool insertComment(Comment comment)
        {
            try
            { 
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Comment> getAllComments()
        {
            var listComment = dbContext.Comments.ToList();

            return listComment;
        }

        public void deleteComment(string idComment)
        {
            var deleteComment = dbContext.Comments.SingleOrDefault(x => x.id == idComment);

            dbContext.Comments.Remove(deleteComment);
            dbContext.SaveChanges();
        }

        public List<CommentModel> getAllCommentModelsOfPost(string postId)
        {
            var comments = (from comment in dbContext.Comments
                            join user in dbContext.Users
                            on comment.uid equals user.id
                            where comment.post_id == postId
                            orderby comment.time descending
                            select new CommentModel()
                            {
                                PostId = comment.post_id,
                                UserOfComment = new UserAvatarModel()
                                {
                                    Id = user.id,
                                    Username = user.username,
                                    Avatar = user.avatar
                                },
                                Content = comment.content
                            });

            return comments.ToList();
        }
    }
}