using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Database.Dao
{
    public interface IFavoriteDao
    {
        int getNumberOfLikesInPost(string postId);

        bool isLikeByUser(string userId, string postId);

        bool toggleLikeAPost(string userId, string postId);
    }
}
