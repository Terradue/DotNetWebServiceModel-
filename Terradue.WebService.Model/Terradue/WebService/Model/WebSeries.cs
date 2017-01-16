using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;
using Terradue.Portal;

namespace Terradue.WebService.Model {
    [Route("/data/collection", "GET", Summary = "GET a list of series", Notes = "Get all existing Series")]
    public class GetAllSeries : IReturn<List<WebSeries>>{}

    [Route("/data/collection/{Id}", "GET", Summary = "GET a list of series", Notes = "Series can be filtered by User Id, Status, ...")]
    public class GetSerie : IReturn<WebSeries>
    {
        [ApiMember(Name="Id", Description = "Series id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/data/collection", "POST", Summary = "POST a series", Notes = "Series can be filtered by User Id, Status, ...")]
    public class CreateSerie : WebSeries, IReturn<WebSeries>{}

    [Route("/data/collection", "PUT", Summary = "PUT a series", Notes = "Series can be filtered by User Id, Status, ...")]
    public class UpdateSerie : WebSeries, IReturn<WebSeries>{}

    [Route("/data/collection/{Id}", "DELETE", Summary = "DELETE a serie", Notes = "Delete a serie from database")]
    public class DeleteSerie : IReturn<List<WebSeries>>
    {
        [ApiMember(Name="Id", Description = "Series id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    public class WebSeries : WebEntity
    {
        [ApiMember(Name="Description", Description = "Series description", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String Description { get; set; }
        [ApiMember(Name="CatalogueDescriptionUrl", Description = "CatalogueDescriptionUrl description", ParameterType = "query", DataType = "String", IsRequired = true)]
        public String CatalogueDescriptionUrl { get; set; }

        /// <summary>
        /// Create a new series
        /// </summary>
        /// <description>
        /// Create a new empty series object
        /// </description>
        public WebSeries (){}

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.DataSeries"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebSeries (Series entity) : base(entity){
            this.Description = entity.Description;
            this.CatalogueDescriptionUrl = entity.CatalogueDescriptionUrl;
        }

        /// <summary>
        /// Tos the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
        public Series ToEntity(IfyContext context, Series input){
            Series entity = (input == null ? new Series(context) : input);

            entity.Identifier = this.Identifier;
            entity.Name = this.Name;
            entity.Description = this.Description;
            entity.DomainId = this.DomainId;
            entity.CatalogueDescriptionUrl = this.CatalogueDescriptionUrl;

            return entity;
        }

    }
}

