namespace FaceGram.Database.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FaceGramDbContext : DbContext
    {
        public FaceGramDbContext()
            : base("name=FaceGramDbContext")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.uid)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.post_id)
                .IsUnicode(false);

            modelBuilder.Entity<Favorite>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Favorite>()
                .Property(e => e.uId)
                .IsUnicode(false);

            modelBuilder.Entity<Favorite>()
                .Property(e => e.pId)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.uid)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Post)
                .HasForeignKey(e => e.post_id);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.Post)
                .HasForeignKey(e => e.pId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Relationship>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Relationship>()
                .Property(e => e.uId)
                .IsUnicode(false);

            modelBuilder.Entity<Relationship>()
                .Property(e => e.fId)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.uid)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.role1)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.uid);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.uId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.uid);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Relationships)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Relationships1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.uId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Role)
                .WithRequired(e => e.User);
        }
    }
}
