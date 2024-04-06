using Blog.Models.ViewModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentsController : Controller
    {
        private readonly ICommentRepository _commentRepository;


        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var comments = await _commentRepository.GetAllAsync();
            return View(comments);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedComment = await _commentRepository.DeleteAsync(id);

            if (deletedComment != null)
            {
                // Show success notification
                return RedirectToAction("List", "Comments");
            }

            return RedirectToAction("List", "Comments");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var comment = await _commentRepository.GetAsync(id);

            if (comment != null)
            {
                var editCommentViewModel = new EditCommentViewModel
                {
                    Id = comment.Id,
                    Description = comment.Description,
                    ArticleId = comment.ArticleId,
                    UserId = comment.UserId,
                    DateAdded = comment.DateAdded
                };

                return View(editCommentViewModel);
            }

            return View(null);
        }
    }
}
