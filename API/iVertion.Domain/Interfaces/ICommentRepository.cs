using iVertion.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsAsync(int? page);

        Task<Comment> GetCommentByIdAsifiedAsync(int? id);

        Task<List<Comment>> GetCommentsByNameAsync(string? name, int? page);

        Task<List<Comment>> GetCommentsByArticleIdAsync(int? id);
    }
}