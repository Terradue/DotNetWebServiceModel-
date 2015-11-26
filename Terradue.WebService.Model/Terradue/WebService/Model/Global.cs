using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;

/*!

\defgroup WebServices Web Services
@{

@}


\defgroup REST REST handler
@{

\ingroup WebServices

\xrefitem dep "Dependencies" "Dependencies" CRUD \ref TepAccounting

\xrefitem dep "Dependencies" "Dependencies" CRUD \ref TepApplication

\xrefitem dep "Dependencies" "Dependencies" CRUD \ref TepCommunity

\xrefitem dep "Dependencies" "Dependencies" CRUD \ref TepContents

\xrefitem dep "Dependencies" "Dependencies" CRUD \ref TepData

\xrefitem dep "Dependencies" "Dependencies" CRUD \ref TepService

\xrefitem dep "Dependencies" "Dependencies" uses \ref Context to setup the HTTP session


\xrefitem int "Interfaces" "Interfaces" implements \ref T2API interface

@}

\defgroup T2API T2 API
@{

    T2 API is an external backend interface of the platform exposed for any users and mainly intented for the web site pages and widgets to interacts with the system.

    It is a REST web service with usual CRUD (create, read, update, delete) functions for the objects managed by the portal:

    - Data Package
    - Web Feature
    - Group
    - Image
    - News
    - Series
    - Service
    - User
    - Wps Provider

    It also offers for most of the items an OpenSearch interface to discover or search them efficiently.

    \xrefitem cptype_int "Interfaces" "Interfaces"
    

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

