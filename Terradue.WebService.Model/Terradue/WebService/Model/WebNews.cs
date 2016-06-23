using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;
using Terradue.Portal;

namespace Terradue.WebService.Model {

    [Route("/news/search", "GET", Summary = "GET a list of news", Notes = "")]
    public class SearchNews {}


    [Route("/news/description", "GET", Summary = "GET a list of news", Notes = "")]
    public class DescriptionNews {}

    [Route("/news", "GET", Summary = "GET a list of news", Notes = "")]
    public class GetAllNews : IReturn<List<WebNews>>{}

    [Route("/news/{id}", "GET", Summary = "GET a news (id=0 means last news)", Notes = "")]
    public class GetNews : IReturn<WebNews>{
        [ApiMember(Name = "id", Description = "News id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/news", "POST", Summary = "POST a news", Notes = "")]
    public class CreateNews : WebNews, IReturn<WebNews>{}

    [Route("/news", "PUT", Summary = "PUT a news", Notes = "")]
    public class UpdateNews : WebNews, IReturn<WebNews>{}

    [Route("/news/{id}", "DELETE", Summary = "DELETE a news", Notes = "")]
    public class DeleteNews : IReturn<WebNews>{
        [ApiMember(Name = "id", Description = "News id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    public class WebNews : WebEntity {

        [ApiMember(Name = "title", Description = "News title", ParameterType = "query", DataType = "string")]
        public string Title { get; set; }

        [ApiMember(Name = "abstract", Description = "News abstract", ParameterType = "query", DataType = "string")]
        public string Abstract { get; set; }

        [ApiMember(Name = "content", Description = "News content", ParameterType = "query", DataType = "string")]
        public string Content { get; set; }

        [ApiMember(Name = "date", Description = "News date", ParameterType = "query", DataType = "DateTime")]
        public DateTime Date { get; set; }

        [ApiMember(Name = "author", Description = "News author", ParameterType = "query", DataType = "string")]
        public string Author { get; set; }

        [ApiMember(Name = "authorImageUrl", Description = "News author image url", ParameterType = "query", DataType = "string")]
        public string AuthorImageUrl { get; set; }

        [ApiMember(Name = "url", Description = "News url link", ParameterType = "query", DataType = "string")]
        public string Url { get; set; }

        [ApiMember(Name = "tags", Description = "News tags", ParameterType = "query", DataType = "string")]
        public string Tags { get; set; }

        [ApiMember(Name = "type", Description = "News type", ParameterType = "query", DataType = "string")]
        public string Type { get; set; }

        public WebNews() {}
        public WebNews(Article entity) : base(entity) {
            this.Title = entity.Title;
            this.Abstract = entity.Abstract;
            this.Content = entity.Content;
            this.Date = entity.Time;
            this.Author = entity.Author;
            this.AuthorImageUrl = entity.AuthorImageUrl;
            this.Url = entity.Url;
            this.Tags = entity.Tags;
            this.Type = entity.EntityType.Keyword;
        }

        public Article ToEntity(IfyContext context, Article input) {
            Article result = (input == null ? new Article(context) : input);

            result.Title = this.Title;
            result.Abstract = this.Abstract;
            result.Content = this.Content;
            result.Author = this.Author;
            result.AuthorImageUrl = this.AuthorImageUrl;
            result.Url = this.Url;
            result.Tags = this.Tags;
            if (this.Date != DateTime.MinValue) result.Time = this.Date;

            return result;
        }

    }
}

