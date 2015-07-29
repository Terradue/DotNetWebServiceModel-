using System;
using Terradue.Portal;
using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Terradue.WebService.Model {

    [Route("/feature", "GET", Summary = "GET a list of features", Notes = "")]
    public class GetFeatures : IReturn<List<WebFeature>>{}

    [Route("/feature/{id}", "GET", Summary = "GET a feature", Notes = "")]
    public class GetFeature : IReturn<WebFeature>{
        [ApiMember(Name = "id", Description = "Feature id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/feature", "POST", Summary = "POST a feature", Notes = "")]
    public class CreateFeature : WebFeature, IReturn<WebFeature>{}

    [Route("/feature", "PUT", Summary = "PUT a feature", Notes = "")]
    public class UpdateFeature : WebFeature, IReturn<WebFeature>{}

    [Route("/feature/sort", "PUT", Summary = "PUT a list of features", Notes = "")]
    public class SortFeature : List<WebFeature>, IReturn<WebFeature>{}

    [Route("/feature/{id}", "DELETE", Summary = "DELETE a feature", Notes = "")]
    public class DeleteFeature : IReturn<WebResponseBool>{
        [ApiMember(Name = "id", Description = "Feature id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/feature/{id}/image", "POST", Summary = "POST Image file")]
    public class UploadFeatureImage : IRequiresRequestStream, IReturn<WebFeature>
    {
        public System.IO.Stream RequestStream { get; set; }

        [ApiMember(Name="id", Description = "Feature Id", ParameterType = "path", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    public class WebFeature : WebEntity {

        [ApiMember(Name = "Title", Description = "Feature title", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string Title { get; set; }

        [ApiMember(Name = "Description", Description = "Feature description", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string Description { get; set; }

        [ApiMember(Name = "Image", Description = "Feature image", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string Image { get; set; }

        [ApiMember(Name = "ImageStyle", Description = "Feature image style", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string ImageStyle { get; set; }

        [ApiMember(Name = "ButtonText", Description = "Feature button text", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string ButtonText { get; set; }

        [ApiMember(Name = "ButtonLink", Description = "Feature button link", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string ButtonLink { get; set; }

        [ApiMember(Name = "Position", Description = "Feature position", ParameterType = "query", DataType = "int", IsRequired = false)]
        public int Position { get; set; }


        public WebFeature() {}
        public WebFeature(Terradue.Portal.Feature entity) : base(entity) {
            this.Title = entity.Title;
            this.Description = entity.Description;
            this.Image = entity.Image;
            this.ImageStyle = entity.ImageStyle;
            this.ButtonLink = entity.ButtonLink;
            this.ButtonText = entity.ButtonText;
            this.Position = entity.Position;
        }
        public Terradue.Portal.Feature ToEntity(IfyContext context, Terradue.Portal.Feature input){
            Terradue.Portal.Feature feat = (input == null ? new Terradue.Portal.Feature(context) : input);

            feat.Title = this.Title;
            feat.Description = this.Description;
            feat.ButtonLink = this.ButtonLink;
            feat.ButtonText = this.ButtonText;
            feat.Image = this.Image;
            feat.ImageStyle = this.ImageStyle;
            feat.Position = this.Position;

            return feat;
        }
    }
}

