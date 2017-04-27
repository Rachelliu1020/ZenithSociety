using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebSite.Models.IdentityModels
{
    public class UserRoleModel
    {
        
        [Key]
        [Display(Name = "UserName")]
        public string UserId { get; set; }

        public string UserName { get; set; }

        [Key]
        [Display(Name = "RoleName")]
        public string RoleId { get; set; }

        public string RoleName { get; set; }

    }
}
