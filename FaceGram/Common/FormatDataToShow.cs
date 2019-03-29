using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Common
{
    public class FormatDataToShow
    {
        public static string getLikes(int numberLikes)
        {
            if (numberLikes == 0)
            {
                return string.Empty;
            }
            else if (numberLikes == 1)
            {
                return $"{numberLikes} like";
            }
            else
            {
                return $"{numberLikes} likes";
            }
        }
    }
}