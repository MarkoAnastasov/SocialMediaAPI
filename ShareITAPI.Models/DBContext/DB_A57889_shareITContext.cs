using Microsoft.EntityFrameworkCore;

namespace ShareITAPI.Models
{
    public partial class DB_A57889_shareITContext : DbContext
    {
        public DB_A57889_shareITContext()
        {
        }

        public DB_A57889_shareITContext(DbContextOptions<DB_A57889_shareITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<FriendRequests> FriendRequests { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__PostId__3C69FB99");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__UserId__3B75D760");
            });

            modelBuilder.Entity<FriendRequests>(entity =>
            {
                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.FriendRequestsFromUser)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendReq__FromU__6E01572D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendRequestsUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendReq__UserI__6D0D32F4");
            });

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendsFriend)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Friends__FriendI__75A278F5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendsUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Friends__UserId__74AE54BC");
            });

            modelBuilder.Entity<Likes>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Likes__PostId__38996AB5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Likes__UserId__37A5467C");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.MessagesFromUser)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__FromUs__70DDC3D8");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.MessagesToUser)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__ToUser__71D1E811");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasOne(d => d.FromUsed)
                    .WithMany(p => p.NotificationsFromUsed)
                    .HasForeignKey(d => d.FromUsedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__FromU__76969D2E");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__PostI__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NotificationsUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__UserI__3F466844");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(100);

                entity.Property(e => e.PhotoUploaded)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.TimeUploaded).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__UserId__30F848ED");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.AccessToken).HasMaxLength(25);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProfilePicture)
                    .HasColumnType("image");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
