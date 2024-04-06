using Blog.Data;
using Blog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext blogDbContext;

        public CommentRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<ArticlesComment> AddAsync(ArticlesComment articlesComment)
        {
           await blogDbContext.Comments.AddAsync(articlesComment);
           await blogDbContext.SaveChangesAsync();
           return articlesComment;
        }

        public async Task<IEnumerable<ArticlesComment>> GetCommentsByArticleIdAsync(Guid articleId)
        {
            return await blogDbContext.Comments.Where(x => x.ArticleId == articleId).ToListAsync();
        }
    }
}
