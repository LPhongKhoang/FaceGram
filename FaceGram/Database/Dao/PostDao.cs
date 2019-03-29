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

        
        public Post getLatestPostOfUser(string uId)
        {
            var latestPost = (from post in dbContext.Posts               
                        where post.uid == uId
                        orderby post.time descending
                        select new
                        {
                            PostId = post.id,
                            PostContent = post.content,
                            PostImage = post.image,
                            PostTime = post.time
                        }).FirstOrDefault();
            return new Post() { id = latestPost.PostId, image = latestPost.PostImage, content = latestPost.PostContent, time = latestPost.PostTime };
        }
    }
}