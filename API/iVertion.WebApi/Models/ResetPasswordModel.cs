using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.WebApi.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set;}
    }
}