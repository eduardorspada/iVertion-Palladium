using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.WebApi.Models
{
    public class EditUserNameModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}