namespace FaceGram.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [StringLength(20)]
        public string id { get; set; }

        [StringLength(20)]
        public string uid { get; set; }

        [StringLength(20)]
        public string post_id { get; set; }

        [StringLength(200)]
        public string content { get; set; }

        public DateTime? time { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
