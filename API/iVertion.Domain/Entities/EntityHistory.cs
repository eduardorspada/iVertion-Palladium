using System;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Domain.Entities
{
    public abstract class EntityHistory
    {
        [Key]
        public int Id { get; protected set; }
        public bool Active { get; protected set; }
        public string? UserId { get; protected set; }
        private DateTime? _createdtedAt;
        public DateTime? CreatedAt
        {
            get { return _createdtedAt; }
            protected set { _createdtedAt = (value == null ? DateTime.UtcNow : value); }
        }
    }
}