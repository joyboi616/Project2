using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Project2.Database
{
    public partial class Series
    {
        [Key]
        [Column("FavShowrunnerID")]
        public int FavShowrunnerId { get; set; }
        [Required]
        [StringLength(20)]
        public string FavShowrunnerName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavEpisodeName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavShowName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavEsceneName { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Series")]
        public virtual User User { get; set; }
    }
}
