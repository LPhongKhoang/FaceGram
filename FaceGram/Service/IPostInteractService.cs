using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Service
{
    public interface IPostInteractService
    {
        bool toggleLikeAPost(string userId, string postId);

        int getNumberLikedOfPost(string postId);

        bool addComment(string userId, string text, string postId);
        

    }
}
