namespace FaceGram.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            Posts1 = new HashSet<Post>();
            Users1 = new HashSet<User>();
            Users = new HashSet<User>();
        }

        [StringLength(20)]
        public string id { get; set; }

        [StringLength(20)]
        public string fullname { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(32)]
        public string password { get; set; }

        public bool? gender { get; set; }

        [StringLength(15)]
        public string phone_number { get; set; }

        [StringLength(30)]
        public string website { get; set; }

        [StringLength(1000)]
        public string biography { get; set; }

        [StringLength(500)]
        public string avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
