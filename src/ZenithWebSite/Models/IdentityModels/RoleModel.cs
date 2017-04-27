using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenithWebSite.Models.IdentityModels
{
    public class RoleModel
    {
        [Key, ForeignKey("IdentityRole")]
        public string RoleId { get; set; }
        public IdentityRole IdentityRole { get; set; }

        public string RoleName { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
