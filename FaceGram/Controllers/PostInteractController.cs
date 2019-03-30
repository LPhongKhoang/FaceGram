using FaceGram.Common;
using FaceGram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaceGram.Controllers
{
    public class PostInteractController : BaseUserController
    {
        private IPostInteractService postInteractService;

        public PostInteractController(IPostInteractService postInteractService)
        {
            this.postInteractService = postInteractService;
        }


        [HttpPost]
        public JsonResult Like(string postId)
        {
            string loginedUserId = getUserIdInSession();
            bool result = postInteractService.toggleLikeAPost(loginedUserId, postId);
            int numberOfLiked = postInteractService.getNumberLikedOfPost(postId);
            string showLiked = FormatDataToShow.getLikes(numberOfLiked);
            return Json(new {
                status = result,
                showLiked
            });
        }

        [HttpPost]
        public JsonResult Comment(string postId, string text)
        {
            LoginedUser user = getUserInSession();
            bool result = postInteractService.addComment(user.Id, text, postId);

            return Json(new
            {
                status = result,
                text,
                postId,
                user
            });
        }
    }
}