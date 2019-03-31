using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Models
{
    public class PostDetailModel : PostModel
    {
        public List<CommentModel> AllCommentModels { get; set; }
    }
}