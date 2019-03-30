using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Models;

namespace FaceGram.Service
{
    public interface IAdminService
    {
        List<UserProfileModel> getAllUser();

        string linkClicked { get; set; }

        AdminModel getAdminModel(string linkClicked);

        List<PostProfileModel> getAllPost();

        List<CommentModel> allComment();

        List<FavoriteModel> allFavorite();

        List<RelationshipModel> allRelationship();

        void deleteComment(string id);

        void deleteRelationship(string id);

        void deleteFavorite(string id);
    }
}
