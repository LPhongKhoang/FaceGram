using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceGram.Database.EF;

namespace FaceGram.Models
{
    public class PostProfileModel
    {
        public string id { get; set; }


        public string uid { get; set; }


        public string image { get; set; }

        public DateTime? time { get; set; }


        public string content { get; set; }
    }
}