using FaceGram.Common;
using FaceGram.Models;
using FaceGram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return Json(new
            {
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

        [HttpPost]
        public JsonResult CreatePost(UploadPostModel model)
        {

            if (model.postContent != null)
            {
                string fileName = CommonConstant.IMAGE_DEFAULT;
                HttpPostedFileWrapper file = model.postImage;
                if (file != null) { 
                    fileName = postInteractService.saveFileToServer(file);
                }
                if (!string.IsNullOrEmpty(fileName))
                {
                    LoginedUser loginedUser = getUserInSession();


                    string postId = postInteractService.addPost(loginedUser.Id, model.postContent, fileName);
                    if (postId != null)
                    {
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return Json(new
                        {
                            status = true,
                            postId,
                            imagePath = fileName,
                            model.postContent,
                            user = loginedUser
                        });
                    }

                }

            }

            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Json(new { status = false });
        }
    }
}