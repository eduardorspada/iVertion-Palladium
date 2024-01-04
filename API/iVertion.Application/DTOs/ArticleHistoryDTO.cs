using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;

namespace iVertion.Application.DTOs
{
    public sealed class ArticleHistoryDTO : BaseHistoryDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(5)]
        [MaxLength(150)]
        [DisplayName("Title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(5)]
        [MaxLength(25000)]
        [DisplayName("Description")]
        public string? Description { get; set; }
        [DisplayName("Author")]
        public string? Author { get; set; }
        [Required(ErrorMessage = "Category Id is required.")]
        [DisplayName("Category Id")]
        public int CategoryId { get; set; }
        public int ArticleId { get; set; }
        public Article? Article { get; set; }

    }
}