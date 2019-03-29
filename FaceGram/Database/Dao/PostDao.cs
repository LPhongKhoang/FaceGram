using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.EF;

namespace FaceGram.Database.Dao
{
    public class PostDao : IPostDao
    {
        FaceGramDbContext dbContext;

        public PostDao(FaceGramDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int getNumberPostUser(string uid)
        {
            int numberPost = dbContext.Posts.Count(x => x.uid.Equals(uid));

            return numberPost;
        }

        public List<Post> getCurrentUserPost(string uid)
        {
            var listPost = dbContext.Posts.Where(x => x.uid.Equals(uid)).OrderByDescending(x => x.time).ToList();

            return listPost;
        }

        
    }
}