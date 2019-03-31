using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Models;

namespace FaceGram.Service
{
    public interface IRelationshipService
    {

        string getRelationship(string userId, string friendId);

        bool toggleFollow(string userId, string friendId);

        List<UserAvatarModel> getAllUnFollowUser(string userId);

        List<UserAvatarModel> getSuggestUnFollowUser(string userId);
    }
}
