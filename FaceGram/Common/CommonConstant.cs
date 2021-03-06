﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Common
{
    public class CommonConstant
    {
        /// <summary>
        /// Key to save Data of logined user
        /// </summary>
        public const string USER_SESSION = "UserSession";

        /// <summary>
        /// Role of user _ string in database
        /// </summary>
        public const string ROLE_USER = "user";
        public const string ROLE_ADMIN = "admin";


        /// <summary>
        /// Code for login function
        /// </summary>
        public const char LOGIN_FAIL = '0';
        public const char LOGIN_OK = '1';
        public const char LOGIN_WRONG_PASSWORD = '2';
        public const char LOGIN_WRONG_EMAIL = '3';


        /// <summary>
        /// Location to save image
        /// </summary>
        public const string IMAGE_ROOT = "/Assets/Images/image_post/";
        public const string IMAGE_DEFAULT = "/Assets/Images/image_post/default.png";

        /// <summary>
        /// 2: mean logined User and this User is friend: Friend
        /// 1: mean logined User is following this User: Following
        /// 0: mean no relationship between logined User and this User: Fan/Follow Back
        /// -1: mean logined User is followed by this User: Follow
        /// </summary>
        public const string REL_FRIEND = "Friend";
        public const string REL_FOLLOWING = "Following";
        public const string REL_FAN = "Fan/Follow Back";
        public const string REL_FOLLOW = "Follow";

    }
}