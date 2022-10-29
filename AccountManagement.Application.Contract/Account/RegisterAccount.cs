using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contract.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string FullName { get; set; } 

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string UserName { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Password { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Mobile { get; set; }

        public long RoleId { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public IFormFile ProfilePhoto { get; set; }

    }
}
