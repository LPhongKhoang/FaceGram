using FaceGram.Common;
using FaceGram.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Database.Dao
{
    public class FavoriteDao : IFavoriteDao
    {
        private FaceGramDbContext dbContext;

        public FavoriteDao(FaceGramDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int getNumberOfLikesInPost(string postId)
        {
            int numberOfLikes = dbContext.Favorites.Count(x=>x.pId == postId);
            return numberOfLikes;
        }

        public bool isLikeByUser(string userId, string postId)
        {
            int numberResult = dbContext.Favorites.Count(x => x.uId == userId && x.pId == postId);
            return numberResult >= 1;
        }

        public bool toggleLikeAPost(string userId, string postId)
        {
            try
            {
                bool isLiked = isLikeByUser(userId, postId);
                if (isLiked)
                {
                    dbContext.Favorites.RemoveRange(dbContext.Favorites.Where(x => x.uId == userId && x.pId == postId));
                    
                }
                else
                {
                    Favorite newLike = new Favorite() { id = DateTimeUtils.getKeyTimeStamp(), uId = userId, pId = postId };
                    dbContext.Favorites.Add(newLike);
                }

                dbContext.SaveChanges();

                return !isLiked;
            }catch(Exception e)
            {
                return false;
            }
        }

        public List<Favorite> getAllFavorite()
        {
            return dbContext.Favorites.ToList();
        }

        public void deleteFavorite(string idFavo)
        {
            var deleteFavorite = dbContext.Favorites.SingleOrDefault(x => x.id == idFavo);

            dbContext.Favorites.Remove(deleteFavorite);
            dbContext.SaveChanges();
        }
    }
}