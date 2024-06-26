﻿namespace Blog.Models.Domain
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        // Navigation property
        public ICollection<Tag> Tags { get; set; }

        public ICollection<Article> Likes { get; set; }
        public ICollection<ArticlesComment> Comments { get; set; }
    }
}
