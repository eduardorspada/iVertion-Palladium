using System;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; protected set; }
        public bool Active { get; protected set; }
        public string? UserId { get; protected set; }
        private DateTime? _updatedAt;
        public DateTime? UpdatedAt
        {
            get { return _updatedAt; }
            protected set { _updatedAt = (value == null ? DateTime.UtcNow : value); }
        }
  
        public DateTime? CreatedAt { get; protected set; }  
    }
}