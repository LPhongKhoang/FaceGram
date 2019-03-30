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
        public string Content { get; set; }

        public string Image { get; set; }
    }
}