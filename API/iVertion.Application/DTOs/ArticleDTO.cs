using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using iVertion.Domain.Entities;

namespace iVertion.Application.DTOs
{
    public sealed class ArticleDTO : BaseDTO
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
        // public Category? Category { get; set; }
    }
}