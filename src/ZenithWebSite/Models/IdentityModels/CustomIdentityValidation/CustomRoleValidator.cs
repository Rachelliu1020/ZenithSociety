using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZenithWebSite.Models.IdentityModels.CustomIdentityValidation
{
    public class CustomRoleValidator<TRole> : RoleValidator<TRole> where TRole : IdentityRole
    {
        //private RoleManager<TRole> Manager { get; set; }
        //public customRoleValidation(RoleManager<TRole> manager) : base()
        //{
        //    Manager = manager;
        //}
        public override Task<IdentityResult> ValidateAsync(RoleManager<TRole> roleManager, TRole role)
        {
            //if (role.Name ==  null) {
            //    return Task.FromResult(
            //        IdentityResult.Failed(new IdentityError
            //        {
            //            Code = "nullRoll",
            //            Description = "Role Name is null."
            //        })
            //    );
            //}
            
            //if (roleManager.Roles.Any(r => r.Name == role.Name)) {
            //    return Task.FromResult(
            //       IdentityResult.Failed(new IdentityError
            //       {
            //           Code = "ingRoleName",
            //           Description = "Role Name has Excisted."
            //       })
            //   );
            //}


            //if (userManager..Any(allowed =>user.Email.EndsWith(allowed, StringComparison.CurrentCultureIgnoreCase))){
            //    return Task.FromResult(IdentityResult.Success);
            //}

            return Task.FromResult(IdentityResult.Success);


        }

    }

    
}
