using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Project2.Database
{
    [Keyless]
    public partial class ClientMusicArtist
    {
        [Column("ArtistID")]
        public int ArtistId { get; set; }
        [Required]
        [StringLength(20)]
        public string ArtistRealName { get; set; }
        [Required]
        [StringLength(20)]
        public string ArtistNickName { get; set; }
        [Required]
        [StringLength(20)]
        public string ArtistAlbums { get; set; }
        public long ReleasedSongs { get; set; }
    }
}
