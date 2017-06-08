using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;
using Terradue.Portal;

namespace Terradue.WebService.Model {

    [Route("/image", "GET", Summary = "GET a list of images", Notes = "")]
    public class GetImages : IReturn<List<WebImage>>{}

    [Route("/image/{id}", "GET", Summary = "GET an image (id=0 means last image)", Notes = "")]
    public class GetImage : IReturn<WebImage>{
        [ApiMember(Name = "id", Description = "image id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/image", "POST", Summary = "POST an image", Notes = "")]
    public class CreateImage : WebImage, IReturn<WebImage>{}

    [Route("/image", "PUT", Summary = "PUT an image", Notes = "")]
    public class UpdateImage : WebImage, IReturn<WebImage>{}

    [Route("/image/{id}", "DELETE", Summary = "DELETE an image", Notes = "")]
    public class DeleteImage : IReturn<WebImage>{
        [ApiMember(Name = "id", Description = "image id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/image/{id}", "POST", Summary = "POST Image file")]
    public class UploadImage : IRequiresRequestStream, IReturn<WebResponseBool>
    {
        public System.IO.Stream RequestStream { get; set; }

        [ApiMember(Name="id", Description = "Feature Id", ParameterType = "path", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    public class WebImage : WebEntity {

        [ApiMember(Name = "caption", Description = "Image caption", ParameterType = "query", DataType = "string")]
        public string Caption { get; set; }

        [ApiMember(Name = "description", Description = "Image description", ParameterType = "query", DataType = "string")]
        public string Description { get; set; }

        [ApiMember(Name = "url", Description = "Image url", ParameterType = "query", DataType = "string")]
        public string Url { get; set; }

        public WebImage() {}
        public WebImage(Image entity) : base(entity) {
            this.Caption = entity.Caption;
            this.Description = entity.Description;
            this.Url = entity.Url;
        }

        public Image ToEntity(IfyContext context, Image input) {
            Image img = (input == null ? new Image(context) : input);

            img.Caption = this.Caption;
            img.Description = this.Description;
            img.Url = this.Url;

            return img;
        }
    }
}

