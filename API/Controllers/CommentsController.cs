using API.Contracts.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    //[ApiController]
    //[Route("[controller]")]
    //[Authorize(Roles = "Admin")]
    //public class CommentsController : Controller
    //{
    //    private readonly ICommentService _commentService;


    //    public CommentsController(ICommentService commentService)
    //    {
    //        _commentService = commentService;

    //    }

    //    [HttpGet]
    //    [Route("All")]
    //    public async Task<IActionResult> List()
    //    {
    //        var comments = await _commentService.GetAllAsync();
           
    //        return comments;
    //    }


    //    [HttpPost]
    //    public async Task<IActionResult> Delete(Guid id)
    //    {
    //        var deletedComment = await _commentRepository.DeleteAsync(id);

    //        if (deletedComment != null)
    //        {
    //            // Show success notification
    //            _logger.LogInformation("CommentsController - обращение к методу Delete");
    //            return RedirectToAction("List", "Comments");
    //        }
    //        _logger.LogInformation("CommentsController - обращение к методу Delete");
    //        return RedirectToAction("List", "Comments");
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Edit(Guid id)
    //    {
    //        var comment = await _commentRepository.GetAsync(id);

    //        if (comment != null)
    //        {
    //            var editCommentViewModel = new EditCommentViewModel
    //            {
    //                Id = comment.Id,
    //                Description = comment.Description,
    //                ArticleId = comment.ArticleId,
    //                UserId = comment.UserId,
    //                DateAdded = comment.DateAdded
    //            };
    //            _logger.LogInformation("CommentsController - обращение к методу Edit");
    //            return View(editCommentViewModel);
    //        }
    //        _logger.LogInformation("CommentsController - обращение к методу Edit");
    //        return View(null);
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Edit(EditCommentViewModel editCommentViewModel)
    //    {
    //        var comment = new ArticlesComment
    //        {
    //            Id = editCommentViewModel.Id,
    //            Description = editCommentViewModel.Description,
    //            ArticleId = editCommentViewModel.ArticleId,
    //            UserId = editCommentViewModel.UserId,
    //            DateAdded = editCommentViewModel.DateAdded
    //        };

    //        var updatedComment = await _commentRepository.UpdateAsync(comment);

    //        if (updatedComment != null)
    //        {
    //            _logger.LogInformation("CommentsController - обращение к методу Edit");
    //            return RedirectToAction("List", "Comments");
    //        }
    //        else
    //        {
    //            _logger.LogInformation("CommentsController - обращение к методу Edit");
    //            return RedirectToAction("Edit", new { id = editCommentViewModel.Id });
    //        }

    //    }


    //}
}
