﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Project2.Database
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaim>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
        }

        [Key]
        public string Id { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string SuperRoleName { get; set; }

        [InverseProperty(nameof(AspNetRoleClaim.Role))]
        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        [InverseProperty(nameof(AspNetUserRole.Role))]
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
