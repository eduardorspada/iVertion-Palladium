using System;
using System.ComponentModel;

namespace iVertion.Application.DTOs
{
    public abstract class BaseDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Active")]
        public bool Active { get; set; }
        [DisplayName("User Id")]
        public string? UserId { get; set; }
        [DisplayName("Updated Date")]
        public DateTime? UpdatedAt { get; set; }
        [DisplayName("Created Date")]
        public DateTime? CreatedAt { get; set; }

    }
}