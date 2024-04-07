using Blog.Models.Domain;
using Blog.Models.ViewModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ArticlesController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IArticleRepository articleRepository;

        public ArticlesController(ITagRepository tagRepository, IArticleRepository articleRepository)
        {
            this.tagRepository = tagRepository;
            this.articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await tagRepository.GetAllAsync();

            var model = new AddArticleViewModel
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddArticleViewModel addArticleViewModel)
        {

            var article = new Article
            {
                Heading = addArticleViewModel.Heading,
                PageTitle = addArticleViewModel.PageTitle,
                Content = addArticleViewModel.Content,
                ShortDescription = addArticleViewModel.ShortDescription,
                FeaturedImageUrl = addArticleViewModel.FeaturedImageUrl,
                UrlHandle = addArticleViewModel.UrlHandle,
                PublishedDate = addArticleViewModel.PublishedDate,
                Author = addArticleViewModel.Author,
                Visible = addArticleViewModel.Visible,
            };


            var selectedTags = new List<Tag>();

            foreach (var selectedTagId in addArticleViewModel.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTagIdAsGuid);

                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }

            article.Tags = selectedTags;

            await articleRepository.AddAsync(article);
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var articles = await articleRepository.GetAllAsync();
            return View(articles);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var article = await articleRepository.GetAsync(id);
            var tagsDomainModel = await tagRepository.GetAllAsync();

            if (article != null)
            {
                var model = new EditArticleViewModel
                {
                    Id = article.Id,
                    Heading = article.Heading,
                    PageTitle = article.PageTitle,
                    Content = article.Content,
                    ShortDescription = article.ShortDescription,
                    FeaturedImageUrl = article.FeaturedImageUrl,
                    UrlHandle = article.UrlHandle,
                    PublishedDate = article.PublishedDate,
                    Author = article.Author,
                    Visible = article.Visible,
                    Tags = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),
                    SelectedTags = article.Tags.Select(x => x.Id.ToString()).ToArray()
                };

                return View(model);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditArticleViewModel editArticleViewModel)
        {

            var articleDomainModel = new Article
            {
                Id = editArticleViewModel.Id,
                Heading = editArticleViewModel.Heading,
                PageTitle = editArticleViewModel.PageTitle,
                Content = editArticleViewModel.Content,
                ShortDescription = editArticleViewModel.ShortDescription,
                FeaturedImageUrl = editArticleViewModel.FeaturedImageUrl,
                UrlHandle = editArticleViewModel.UrlHandle,
                PublishedDate = editArticleViewModel.PublishedDate,
                Author = editArticleViewModel.Author,
                Visible = editArticleViewModel.Visible
            };

            var selectedTags = new List<Tag>();
            foreach (var selectedTag in editArticleViewModel.SelectedTags)
            {
                if (Guid.TryParse(selectedTag, out var tag))
                {
                    var foundTag = await tagRepository.GetAsync(tag);

                    if (foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }

            }

            articleDomainModel.Tags = selectedTags;

            var updatedArticle = await articleRepository.UpdateAsync(articleDomainModel);

            if (updatedArticle != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(EditArticleViewModel editArticleViewModel)
        {
            var deletedArticle = await articleRepository.DeleteAsync(editArticleViewModel.Id);

            if (deletedArticle != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editArticleViewModel.Id });
        }


        [HttpGet]
        public async Task<IActionResult> GetArticlesByAuthor(string userName)
        {
            
            var articles = await articleRepository.GetArticlesByAuthorAsync(userName);

            return View(articles);
        }
    }
}
