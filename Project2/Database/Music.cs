using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Project2.Database
{
    [Table("Music")]
    public partial class Music
    {
        [Key]
        [Column("FavArtistID")]
        public int FavArtistId { get; set; }
        [Required]
        [StringLength(20)]
        public string FavArtistName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavSongName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavAlbumName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavMusicVideoName { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Musics")]
        public virtual User User { get; set; }
    }
}
