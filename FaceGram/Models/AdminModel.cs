using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Models
{
    public class AdminModel
    {
        public List<UserProfileModel> listUserProfileModel { get; set; }

        public List<PostProfileModel> listPostProfileModel { get; set; }

        public List<CommentModel> listCommentModel { get; set; }

        public List<RelationshipModel> listRelationshipModel { get; set; }

        public List<FavoriteModel> listFavoriteModel { get; set; }

        public string linkClick { get; set; }
    }
}