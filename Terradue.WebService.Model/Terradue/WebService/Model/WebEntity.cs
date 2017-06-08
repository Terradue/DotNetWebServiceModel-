using System;
using ServiceStack.ServiceHost;
using Terradue.Portal;

namespace Terradue.WebService.Model {

    public class HttpOptions {
        [ApiMember(Name="Get", Description = "Http Get option", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Get { get; set; }

        [ApiMember(Name="Post", Description = "Http Post option", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Post { get; set; }

        [ApiMember(Name="Put", Description = "Http Put option", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Put { get; set; }

        [ApiMember(Name="Delete", Description = "Http Delete option", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Delete { get; set; }

        public HttpOptions () {
            Get = false;
            Post = false;
            Put = false;
            Delete = false;
        }

        public HttpOptions (Entity entity) {
            Get = entity.CanView;
            Post = entity.CanCreate;
            Put = entity.CanChange;
            Delete = entity.CanDelete;
        }
    }

    public class WebEntity {
        [ApiMember(Name="Id", Description = "Entity id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
        [ApiMember(Name="Identifier", Description = "Entity identifier", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Identifier { get; set; }
        [ApiMember(Name="Name", Description = "Entity Name", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Name { get; set; }
        [ApiMember (Name = "DomainId", Description = "Entity domain id", ParameterType = "query", DataType = "int", IsRequired = false)]
        public int DomainId { get; set; }
        [ApiMember(Name="Options", Description = "Entity Options", ParameterType = "query", DataType = "HttpOptions", IsRequired = false)]
        public HttpOptions Options { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.Entity"/> class.
        /// </summary>
        public WebEntity (){
            Options = new HttpOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.Entity"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebEntity (Entity entity){
            this.Id = entity.Id;
            this.Identifier = entity.Identifier;
            this.Name = entity.Name;
            this.DomainId = entity.DomainId.ToString();
            this.Options = new HttpOptions(entity);
        }
    }
}

