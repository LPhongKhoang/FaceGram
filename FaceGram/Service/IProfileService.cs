using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Database.EF;
using FaceGram.Models;

namespace FaceGram.Service
{
    public interface IProfileService
    {
        UserProfileModel getUser(string userID);

        ProfileModel getProfileModel(string userID, string loginedUserId);

        List<PostProfileModel> getCurrentPost(string userID);

    }
}
