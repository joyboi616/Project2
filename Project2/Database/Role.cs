using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Project2.Database
{
    public partial class Role
    {
        [Key]
        [Column("RolesID")]
        public int RolesId { get; set; }
        [Required]
        [StringLength(20)]
        public string RolePosition { get; set; }
        [Required]
        [StringLength(20)]
        public string RoleNickName { get; set; }
        [Required]
        [StringLength(20)]
        public string SecondEmail { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Roles")]
        public virtual User User { get; set; }
    }
}
