using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceGram.Models
{
    public class UploadPostModel
    {
        [Required()]
        public string postContent { get; set; }

        public HttpPostedFileWrapper postImage { get; set; }
    }
}