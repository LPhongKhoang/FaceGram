using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.EF;

namespace FaceGram.Models
{
    public class ProfileModel
    {
        public UserProfileModel UserProfileModel { get; set; }

        public int NumberPostUser { get; set; }

        public int NumberUserFollow { get; set; }

        public int NumberRelationship { get; set; }

        public List<PostProfileModel> GetcurrentPost { get; set; }
    }
}