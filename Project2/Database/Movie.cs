using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Project2.Database
{
    public partial class Movie
    {
        [Key]
        [Column("FavDirectorID")]
        public int FavDirectorId { get; set; }
        [Required]
        [StringLength(20)]
        public string FavDirectorName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavMovieName { get; set; }
        [Required]
        [StringLength(20)]
        public string FavFranchiseName { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Movies")]
        public virtual User User { get; set; }
    }
}
