using FaceGram.Database.EF;
using FaceGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Database.Dao
{
    public interface ICommentDao
    {
        List<CommentModel> getTop3CommentModels(string postId);

        bool insertComment(Comment comment);

        List<Comment> getAllComments();

        void deleteComment(string idComment);

        List<CommentModel> getAllCommentModelsOfPost(string postId);
    }
}
