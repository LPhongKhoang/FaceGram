namespace FaceGram.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Relationship")]
    public partial class Relationship
    {
        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(20)]
        public string uId { get; set; }

        [Required]
        [StringLength(20)]
        public string fId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
