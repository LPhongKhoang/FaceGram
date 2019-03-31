using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceGram.Models;

namespace FaceGram.Service
{
    public interface IEditProfileService
    {
        UserProfileModel getUser(string userID);

        ProfileModel getProfileModel(string userID);

        void editUserProfile(UserProfileModel userProfileModel, string uid);
    }
}
