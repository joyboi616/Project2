using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project2.Database
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<ClientMusicArtist> ClientMusicArtists { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=pc-de-steban.database.windows.net;Initial Catalog=Nov15Example;Persist Security Info=True;User ID=superadmin;Password=Cafe616001");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<ClientMusicArtist>(entity =>
            {
                entity.Property(e => e.ArtistId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.FavDirectorId)
                    .HasName("PK__Movies__8FEDEF4428EA0988");

                entity.Property(e => e.FavDirectorName).IsUnicode(false);

                entity.Property(e => e.FavFranchiseName).IsUnicode(false);

                entity.Property(e => e.FavMovieName).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Movies_Users");
            });

            modelBuilder.Entity<Music>(entity =>
            {
                entity.HasKey(e => e.FavArtistId)
                    .HasName("PK__Music__9ADBA9F1575D9255");

                entity.Property(e => e.FavAlbumName).IsUnicode(false);

                entity.Property(e => e.FavArtistName).IsUnicode(false);

                entity.Property(e => e.FavMusicVideoName).IsUnicode(false);

                entity.Property(e => e.FavSongName).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Musics)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Music_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolesId)
                    .HasName("PK__Roles__C4B2782006AA0018");

                entity.Property(e => e.RoleNickName).IsUnicode(false);

                entity.Property(e => e.RolePosition).IsUnicode(false);

                entity.Property(e => e.SecondEmail).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Roles_Users");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.FavShowrunnerId)
                    .HasName("PK__Series__685179ACA2D5FF13");

                entity.Property(e => e.FavEpisodeName).IsUnicode(false);

                entity.Property(e => e.FavEsceneName).IsUnicode(false);

                entity.Property(e => e.FavShowName).IsUnicode(false);

                entity.Property(e => e.FavShowrunnerName).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Series_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.NickName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
