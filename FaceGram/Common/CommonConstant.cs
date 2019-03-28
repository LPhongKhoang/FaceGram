using System;
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
        /// Code for login function
        /// </summary>
        public const char LOGIN_FAIL = '0';
        public const char LOGIN_OK = '1';
        public const char LOGIN_WRONG_PASSWORD = '2';
        public const char LOGIN_WRONG_EMAIL = '3';

    }
}