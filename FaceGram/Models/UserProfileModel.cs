using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceGram.Models
{
    public class UserProfileModel
    { 
        public string id { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public bool? gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number not valid")]
        public string phone_number { get; set; }

        public string website { get; set; }

        public string biography { get; set; }

        public string avatar { get; set; }

        public string RelationshipStatus { get; set; }
    }
}