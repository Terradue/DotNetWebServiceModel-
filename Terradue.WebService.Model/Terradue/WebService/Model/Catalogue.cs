using System;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;

namespace Terradue.WebService.Model
{
	[Route("/catalogue/{serieId}/description", "GET", Summary = "GET a serie descriptions", Notes = "")]
	[Route("/data/collection/{serieId}/description", "GET", Summary = "GET a serie descriptions", Notes = "")]
	public class GetOpensearchDescription : IReturn<HttpResult>
	{
		[ApiMember(Name="serieId", Description = "Series id", ParameterType = "query", DataType = "string", IsRequired = true)]
		public string serieId { get; set; }
	}

	[Route("/catalogue/description", "GET", Summary = "GET a list of series descriptions", Notes = "")]
    [Route("/data/collection/description", "GET", Summary = "GET a list of series descriptions", Notes = "")]
	public class GetOpensearchDescriptions : IReturn<HttpResult>{}

	[Route("/catalogue/{serieId}/search", "GET", Summary = "GET a serie search", Notes = "")]
    [Route("/data/collection/{serieId}/search", "GET", Summary = "GET a serie search", Notes = "")]
	public class GetOpensearchSearch
	{
		[ApiMember(Name="serieId", Description = "Series id", ParameterType = "query", DataType = "string", IsRequired = true)]
		public string serieId { get; set; }
	}

	[Route("/catalogue/search", "GET", Summary = "GET a list of series search", Notes = "")]
    [Route("/data/collection/search", "GET", Summary = "GET a list of series search", Notes = "")]
	public class GetOpensearchSearchs{}

    [Route("/data/package/search", "GET", Summary = "search for datapackage", Notes = "Return all data packages accessible by the user")]
    public class DataPackagesSearchRequest {}

    [Route("/data/package/description", "GET", Summary = "opensearch description for datapackage", Notes = "Return all data packages accessible by the user")]
    public class DataPackagesDescriptionRequest {}

    [Route("/data/package/{DataPackageId}/search", "GET", Summary = "search into the items of a datapackage", Notes = "Data Package is selected from its ID")]
    public class DataPackageSearchRequest {

        [ApiMember(Description = "DataPackage ID", ParameterType = "query", DataType = "string", IsRequired = true)]
        public string DataPackageId { get; set; }

        [ApiMember(Name="key", Description = "DataPackage access Key", ParameterType = "query", DataType = "string", IsRequired = false)]
        public string Key { get; set; }

    }

    [Route("/data/package/{DataPackageId}/description", "GET", Summary = "Opensearch Description of a data package", Notes = "Data package is selected from its ID")]
    public class DataPackageDescriptionRequest : IReturn<HttpResult> {

        [ApiMember(Description = "DataPackage ID", ParameterType = "query", DataType = "string", IsRequired = true)]
        public string DataPackageId { get; set; }

        [ApiMember(Name="key", Description = "DataPackage access Key", ParameterType = "query", DataType = "string", IsRequired = false)]
        public string Key { get; set; }

    }
}



