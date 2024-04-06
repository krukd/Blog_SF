using Blog.Models.Domain;

namespace Blog.Repositories
{
    public interface ICommentRepository
    {
        Task<ArticlesComment> AddAsync(ArticlesComment articlesComment);

        Task<IEnumerable<ArticlesComment>> GetCommentsByArticleIdAsync(Guid articleId);

       
    }
}
