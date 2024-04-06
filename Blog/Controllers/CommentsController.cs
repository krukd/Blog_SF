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
    }
}
