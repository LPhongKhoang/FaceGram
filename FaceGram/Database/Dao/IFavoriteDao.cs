using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Database.EF;

namespace FaceGram.Database.Dao
{
    public interface IFavoriteDao
    {
        int getNumberOfLikesInPost(string postId);

        bool isLikeByUser(string userId, string postId);

        bool toggleLikeAPost(string userId, string postId);

        List<Favorite> getAllFavorite();

        void deleteFavorite(string idFavo);
    }
}
