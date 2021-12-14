using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Project2.Database
{
    public partial class User
    {
        public User()
        {
            Movies = new HashSet<Movie>();
            Musics = new HashSet<Music>();
            Roles = new HashSet<Role>();
            Series = new HashSet<Series>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string NickName { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string Email { get; set; }
        public long PhoneNumber { get; set; }

        [InverseProperty(nameof(Movie.User))]
        public virtual ICollection<Movie> Movies { get; set; }
        [InverseProperty(nameof(Music.User))]
        public virtual ICollection<Music> Musics { get; set; }
        [InverseProperty(nameof(Role.User))]
        public virtual ICollection<Role> Roles { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Series> Series { get; set; }
    }
}
