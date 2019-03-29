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
        UserProfileModel getUser(string userID);

        AdminModel getProfileModel(string userID, string linkClicked);
    }
}
