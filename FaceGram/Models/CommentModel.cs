﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Models
{
    public class CommentModel
    {
        public string PostId { get; set; }

        public UserAvatarModel UserOfComment { get; set; }

        public string Content { get; set; }
    }
}