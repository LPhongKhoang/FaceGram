namespace FaceGram.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(20)]
        public string uId { get; set; }

        [Required]
        [StringLength(20)]
        public string pId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
