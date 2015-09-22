using System;
using ServiceStack.ServiceHost;
using System.Collections.Generic;

/*!

\defgroup Model Model
@{

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

