using Blog.Models.Domain;
using Blog.Models.ViewModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleLikesController : ControllerBase
    {
        private readonly IArticleLikesRepository articleLikesRepository;

        public ArticleLikesController(IArticleLikesRepository articleLikesRepository)
        {
            this.articleLikesRepository = articleLikesRepository;
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeViewModel addLikeViewModel)
        {
            var model = new ArticleLike
            {
                ArticleId = addLikeViewModel.ArticleId,
                UserId = addLikeViewModel.UserId
            };

            await articleLikesRepository.AddLikeForArticle(model);

            return Ok();
        }


        [HttpGet]
        [Route("{articleId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikesForArticle([FromRoute] Guid articleId)
        {
           var totalLikes = await articleLikesRepository.GetTotalLikes(articleId);

           return Ok(totalLikes);
        }
    }
}
