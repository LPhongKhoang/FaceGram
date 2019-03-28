namespace FaceGram.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [Key]
        [StringLength(20)]
        public string uid { get; set; }

        [Column("role")]
        [StringLength(10)]
        public string role1 { get; set; }

        public virtual User User { get; set; }
    }
}
