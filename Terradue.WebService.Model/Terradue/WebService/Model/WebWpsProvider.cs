using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;
using Terradue.Portal;
using ServiceStack.Common.Web;

namespace Terradue.WebService.Model {

    [Route("/cr/wps", "GET", Summary = "GET a list of WPS providers", Notes = "")]
    public class GetWPSProviders : IReturn<List<WebWpsProvider>>{}

    [Route("/cr/wps/{Id}", "GET", Summary = "POST a WPS provider", Notes = "")]
    public class GetWPSProvider : IReturn<WebWpsProvider> {
        [ApiMember(Name = "Id", Description = "Provider id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/cr/wps/search", "GET", Summary = "GET a list of WPS providers", Notes = "")]
    public class SearchWPSProviders : IReturn<HttpResult>{}

    [Route("/cr/wps/{Identifier}/description", "GET", Summary = "GET a list of WPS providers", Notes = "")]
    public class GetWPSProvidersDescription : IReturn<HttpResult>{
        [ApiMember(Name="Identifier", Description = "Identifier", ParameterType = "query", DataType = "string", IsRequired = true)]
        public string Identifier { get; set; }
    }
    
    [Route("/cr/wps", "POST", Summary = "POST a WPS provider", Notes = "")]
    public class CreateWPSProvider : WebWpsProvider, IReturn<WebWpsProvider>{}

    [Route("/cr/wps", "PUT", Summary = "PUT a WPS provider", Notes = "")]
    public class UpdateWPSProvider : WebWpsProvider, IReturn<WebWpsProvider>{
        [ApiMember(Name="mode", Description = "service update mode", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Mode { get; set; }
    }

    [Route("/wps/WebProcessingService", "GET", Summary = "Web Processing Services", Notes = "")]
    public class GetWebProcessingServices : IReturn<HttpResult>{
        [ApiMember(Name="service", Description = "service type", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Service { get; set; }
        [ApiMember(Name="request", Description = "request type", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Request { get; set; }
        [ApiMember(Name="identifier", Description = "request identifier", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Identifier { get; set; }
        [ApiMember(Name="version", Description = "request version", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Version { get; set; }
        [ApiMember(Name="dataInputs", Description = "request data inputs", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String DataInputs { get; set; }
        [ApiMember(Name="responseDocument", Description = "request response document", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String ResponseDocument { get; set; }
    }

    [Route("/wps/RetrieveResultServlet", "GET", Summary = "Retrieve results servlets", Notes = "")]
    public class GetResultsServlets : IReturn<HttpResult>{
        [ApiMember(Name="id", Description = "servlet id", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Id { get; set; }
    }

    [Route("/cr/wps/{Id}", "DELETE", Summary = "POST a WPS provider", Notes = "")]
    public class DeleteWPSProvider : IReturn<bool>{
        [ApiMember(Name="Id", Description = "Provider id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    public class WebWpsProvider : WebEntity {
        [ApiMember(Name="Url", Description = "WPS url", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Url { get; set; }
        [ApiMember(Name="Proxy", Description = "Define if WPS has to be proxied", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Proxy { get; set; }
        [ApiMember(Name="Contact", Description = "WPS contact point", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Contact { get; set; }
        [ApiMember(Name = "AutoSync", Description = "Is service auto synchronized", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool AutoSync { get; set; }
        [ApiMember(Name = "StageResults", Description = "Is service staging results", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool StageResults { get; set; }
        [ApiMember(Name = "Tags", Description = "Provider Tags", ParameterType = "query", DataType = "List<string>", IsRequired = false)]
        public List<string> Tags { get; set; }

        public WebWpsProvider() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.WebWpsProvider"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebWpsProvider(WpsProvider entity) : base(entity) {
            this.Url = entity.BaseUrl;
            this.Proxy = entity.Proxy;
            this.Contact = entity.Contact;
            this.AutoSync = entity.AutoSync;
            this.StageResults = entity.StageResults;
            this.Tags = entity.GetTagsAsList();
        }

        /// <summary>
        /// Tos the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
        public WpsProvider ToEntity(IfyContext context, WpsProvider input){
            WpsProvider entity = (input == null ? new WpsProvider(context) : input);

            entity.Identifier = this.Identifier;
            entity.Name = this.Name;
            if (!string.IsNullOrEmpty(this.DomainId)) entity.DomainId = Int32.Parse(this.DomainId);
            entity.BaseUrl = this.Url;
            entity.Proxy = this.Proxy;
            entity.Contact = this.Contact;
            entity.AutoSync = this.AutoSync;
            entity.StageResults = this.StageResults;
            if (this.Tags != null && this.Tags.Count > 0) {
                entity.Tags = "";
                foreach (var tag in this.Tags) entity.AddTag(tag);
            } else entity.Tags = null;

            return entity;
        }

    }

}

