using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Common
{
    public class LoginedUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string UserFullName { get; set; }

        public string Avatar { get; set; }

        public string Role { get; set; }
    }
}