using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;

/*!

\defgroup WebServices Web Services
@{

@}


\defgroup REST REST handler
@{

This component enables the full web service stack to interact with the back-end.
It allows to control many of the business objects in the system with REST CRUD (Create, Read, Update, Delete) operations

\ingroup WebServices

\xrefitem dep "Dependencies" "Dependencies" CRUD operations for user accounts managed \ref TepAccounting

\xrefitem dep "Dependencies" "Dependencies" CRUD operations for thematic application managed by \ref TepApplication

\xrefitem dep "Dependencies" "Dependencies" CRUD operations for user and groups managed by \ref TepCommunity

\xrefitem dep "Dependencies" "Dependencies" CRUD operations for editorial contents managed by \ref TepContents

\xrefitem dep "Dependencies" "Dependencies" CRUD operations for collections and data packages managed by \ref TepData

\xrefitem dep "Dependencies" "Dependencies" CRUD operations for services managed by \ref TepService


\xrefitem int "Interfaces" "Interfaces" implements \ref T2API interface

\xrefitem int "Interfaces" "Interfaces" implements \ref OpenSearch interface

@}

\defgroup T2API T2 API
@{

    T2 API is an external backend interface of the platform exposed for any users and mainly intented for the web site pages and widgets to interacts with the system.

    It is a REST web service with usual CRUD (create, read, update, delete) functions for the objects managed by the portal:

    - Collection
    - Data Package
    - Web Feature
    - Group
    - Image
    - News
    - Series
    - Service
    - User
    - Wps Provider
    - Contest
    - Benchmark

    It also offers for most of the items an \ref OpenSearch interface to discover or search them efficiently. The results are provided in the \ref OWSContext model
    and in the feed format requested.

    \xrefitem cptype_int "Interfaces" "Interfaces"

    \xrefitem norm "Normative References" "Normative References" [OpenSearch 1.1](http://www.opensearch.org/Specifications/OpenSearch/1.1)

    \xrefitem norm "Normative References" "Normative References" [OGC OWS Context Conceptual Model](https://portal.opengeospatial.org/files/?artifact_id=55182)

@}

*/

namespace Terradue.WebService.Model {

    //---------------------------------------------------------------------------------------------------------------------

    [Route("/config", "GET", Summary = "GET main config", Notes = "Get main config")]
    public class GetConfig : IReturn<List<KeyValuePair<string, string>>> {}


    //---------------------------------------------------------------------------------------------------------------------

    public class WebKeyValue {
        [ApiMember(Name="Key", Description = "Key", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string Key { get; set; }
        [ApiMember(Name="Value", Description = "Value", ParameterType = "query", DataType = "String", IsRequired = false)]
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.WebNameValue"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        public WebKeyValue(string key, string value){
            this.Key = key;
            this.Value = value;
        }
    }
        
    public class WebResponseString {
        [ApiMember(Name="Response", Description = "Response", ParameterType = "query", DataType = "String", IsRequired = true)]
        public string Response { get; set; }

        public WebResponseString(string response){
            this.Response = response;
        }
    }

    public class WebResponseBool {
        [ApiMember(Name="Response", Description = "Response", ParameterType = "query", DataType = "bool", IsRequired = true)]
        public bool Response { get; set; }

        public WebResponseBool(bool response){
            this.Response = response;
        }
    }
}

