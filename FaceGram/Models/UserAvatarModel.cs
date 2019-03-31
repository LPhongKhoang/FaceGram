using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Models
{
    public class UserAvatarModel
    {
        public string Id { get; set; }

        public string Avatar { get; set; }

        public string Username { get; set; }

        
        public string RelationshipStatus { get; set; }
    }
}