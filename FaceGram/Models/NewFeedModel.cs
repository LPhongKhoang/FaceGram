using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Models
{
    public class NewFeedModel
    {

        public UserAvatarModel UserAvatar { get; set; }

        public List<PostModel> PostModelList { get; set; }

        
    }
}