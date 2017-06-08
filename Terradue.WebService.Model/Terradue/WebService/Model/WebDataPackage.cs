using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;
using Terradue.Portal;

namespace Terradue.WebService.Model {
    [Route("/data/package/{Id}", "GET", Summary = "GET a datapackage", Notes = "")]
    public class GetDataPackage : IReturn<WebDataPackage>
    {
        [ApiMember(Name="Id", Description = "Data Package id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/data/package", "GET", Summary = "GET all datapackages", Notes = "")]
    public class GetAllDataPackages : IReturn<List<WebDataPackage>> {}

    [Route("/data/package", "POST", Summary = "POST a datapackage", Notes = "Add a new datapackage in database")]
    public class CreateDataPackage : WebDataPackage, IReturn<WebDataPackage>{}

    [Route("/data/package", "PUT", Summary = "PUT a datapackage", Notes = "Update a datapackage in database")]
    public class UpdateDataPackage : WebDataPackage, IReturn<WebDataPackage>{}

    [Route("/data/package/{Id}", "DELETE", Summary = "DELETE a datapackage", Notes = "Delete a datapackage from database")]
    public class DeleteDataPackage : IReturn<WebResponseBool>
    {
        [ApiMember(Name="Id", Description = "datapackage id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }
        
    [Route("/data/package/{DpId}/item", "POST", Summary = "POST item to datapackage", Notes = "datapackage item is contained in the body")]
    public class AddItemToDataPackage : WebDataPackageItem, IReturn<WebDataPackage>
    {
        [ApiMember(Name="DpId", Description = "Data Package Id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int DpId { get; set; }
    }

    [Route("/data/package/{DpId}/item/{Id}", "DELETE", Summary = "DELETE item from datapackage", Notes = "")]
    public class RemoveItemFromDataPackage : IReturn<WebDataPackage>
    {
        [ApiMember(Name="DpId", Description = "Data Package Id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int DpId { get; set; }

        [ApiMember(Name="Id", Description = "datapackage id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    public class WebDataPackage : WebEntity
    {
        [ApiMember(Name="Kind", Description = "Remote resource visibility (default = 1)", ParameterType = "path", DataType = "int", IsRequired = true)]
        public int Kind { get; set; }
        [ApiMember(Name="Items", Description = "Data Package Resources", ParameterType = "path", DataType = "List<DataPackageItem>", IsRequired = false)]
        public List<WebDataPackageItem> Items { get; set; }

        public WebDataPackage () {}

        public WebDataPackage (RemoteResourceSet entity) : base(entity){
            this.Kind = entity.Kind;
            this.Items = new List<WebDataPackageItem>();
            foreach (RemoteResource item in entity.Resources) this.Items.Add(new WebDataPackageItem(item));
        }
            
        /// <summary>
        /// Transform into the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
        public RemoteResourceSet ToEntity(IfyContext context, RemoteResourceSet input){
            RemoteResourceSet result = (input == null ? new RemoteResourceSet(context) : input);

            result.Name = this.Name;
            if(this.Identifier == null && this.Name != null) 
                result.Identifier = this.Name.Replace(" ","");
            else 
                result.Identifier = this.Identifier;
            result.Kind = this.Kind;
            if(!string.IsNullOrEmpty(this.DomainId)) result.DomainId = Int32.Parse(this.DomainId);
            return result;
        }
    }

    public class WebDataPackageItem : WebEntity
    {
        [ApiMember(Name="ResourceSetId", Description = "Remote resource set Id", ParameterType = "path", DataType = "int", IsRequired = false)]
        public int ResourceSetId { get; set; }
        [ApiMember(Name="Location", Description = "Remote resource Location", ParameterType = "path", DataType = "string", IsRequired = true)]
        public string Location { get; set; }

        public WebDataPackageItem () {}

        public WebDataPackageItem (RemoteResource entity) : base(entity){
            this.Location = entity.Location;
            this.ResourceSetId = entity.ResourceSetId;
            this.Name = entity.Name;
        }

        public RemoteResource ToEntity(IfyContext context, RemoteResource input){
            RemoteResource result = (input == null ? new RemoteResource(context) : input);

            result.Location = this.Location;
            result.Name = this.Name;
            return result;
        }

    }
}

