using FaceGram.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Common;

namespace FaceGram.Models
{
    public class PostModel
    {
        public UserAvatarModel UserOfPost { get; set; }

        public string PostId { get; set; }

        public string PostImage { get; set; }

        public string PostContent { get; set; }

        public int NumberLikes { get; set; }

        public string FormatLikes
        {
            get
            {
                return FormatDataToShow.getLikes(NumberLikes);
            }
        }

        public List<CommentModel> Top3CommentModels { get; set; }

        public string TimeAgo { get; set; }

        public bool IsLikeByLoginedUser { get; set; }
    }
}