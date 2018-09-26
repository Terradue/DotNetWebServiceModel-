using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;
using Terradue.Portal;
using ServiceStack.Common.Web;

namespace Terradue.WebService.Model {

    [Route("/service/search", "GET", Summary = "GET a list of services", Notes = "")]
    public class SearchServices : IReturn<HttpResult>{
        [ApiMember(Name="cloud", Description = "Service id", ParameterType = "query", DataType = "bool", IsRequired = false)]
        public bool Cloud { get; set; }
    }

    [Route("/service/wps/search", "GET", Summary = "GET a list of WPS services", Notes = "")]
    public class SearchWPSServices : IReturn<HttpResult>{}

    [Route("/service/wps/description", "GET", Summary = "GET a list of WPS services", Notes = "")]
    public class GetWPSProcessDescription : IReturn<HttpResult>{}

    [Route("/service/wps", "GET", Summary = "GET a list of WPS services", Notes = "")]
    public class GetWPSServices : IReturn<List<WebWpsService>>{}

    [Route("/service/wps/{Id}", "GET", Summary = "GET a WPS service", Notes = "")]
    public class GetWPSService : IReturn<WebWpsService>{
        [ApiMember(Name="Id", Description = "Service id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/service/wps", "POST", Summary = "POST a WPS service", Notes = "")]
    public class CreateWPSService : WebWpsService, IReturn<WebWpsService>{}

    [Route("/service/wps", "PUT", Summary = "PUT a WPS service", Notes = "")]
    public class UpdateWPSService : WebWpsService, IReturn<WebWpsService>{}

    [Route("/service/wps/{Id}", "DELETE", Summary = "Delete a WPS service", Notes = "")]
    public class DeleteWPSService : IReturn<bool>{
        [ApiMember(Name="Id", Description = "Service id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    public class WebService : WebEntity {
        [ApiMember(Name="Description", Description = "Service description", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Description { get; set; }
        [ApiMember(Name="Url", Description = "Service url", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Url { get; set; }
        [ApiMember(Name="Version", Description = "Service url", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Version { get; set; }
        [ApiMember(Name="Available", Description = "Is service available", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Available { get; set; }
        [ApiMember(Name = "Quotable", Description = "Is service quotable", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Quotable { get; set; }
        [ApiMember(Name="IconUrl", Description = "Service icon url", ParameterType = "query", DataType = "string", IsRequired = false)]
        public string IconUrl { get; set; }
        [ApiMember(Name = "Tags", Description = "Service Tags", ParameterType = "query", DataType = "List<string>", IsRequired = false)]
        public List<string> Tags { get; set; }

        public WebService() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.WebService"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebService(Service entity) : base(entity) {
            this.Description = entity.Description;
            this.Url = entity.Url;
            this.Version = entity.Version;
            this.Available = entity.Available;
            this.IconUrl = entity.IconUrl;
            this.Tags = entity.GetTagsAsList();
            this.Quotable = entity.Quotable;
        }

        /// <summary>
        /// Tos the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
        public Service ToEntity(IfyContext context, Service input){
            Service entity = input;

            entity.Identifier = this.Identifier;
            entity.Name = this.Name;
            entity.Description = this.Description;
            if (!string.IsNullOrEmpty (this.DomainId)) entity.DomainId = Int32.Parse (this.DomainId);
            entity.Url = this.Url;
            entity.Version = this.Version;
            entity.Available = this.Available;
            entity.IconUrl = this.IconUrl;
            if (this.Tags != null) {
                entity.Tags = "";
                foreach (var tag in this.Tags) entity.AddTag(tag);
            }

            return entity;
        }

    }

    public class WebWpsService : WebService {

        public WebWpsService() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.WebService"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebWpsService(WpsProcessOffering entity) : base(entity) {
        }

        /// <summary>
        /// Tos the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
        public WpsProcessOffering ToEntity(IfyContext context, WpsProcessOffering input){
            WpsProcessOffering entity = (input == null ? new WpsProcessOffering(context) : input);

            if (this.Id == 0) this.Identifier = Guid.NewGuid().ToString();
            entity.Identifier = this.Identifier;
            entity.Name = this.Name;
            entity.Description = this.Description;
            if (!string.IsNullOrEmpty(this.DomainId)) entity.DomainId = Int32.Parse(this.DomainId);
            entity.Url = this.Url;
            entity.Version = this.Version;
            entity.IconUrl = this.IconUrl;
            
            return entity;
        }

    }

}

