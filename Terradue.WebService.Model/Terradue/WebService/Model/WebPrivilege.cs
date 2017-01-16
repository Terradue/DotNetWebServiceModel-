using System.Collections.Generic;
using ServiceStack.ServiceHost;
using Terradue.Portal;
using Terradue.WebService.Model;

namespace Terradue.WebService.Model {
    
    [Route ("/priv", "GET", Summary = "GET the privileges", Notes = "")]
    public class PrivilegesGetRequest : IReturn<List<WebPrivilege>> {}

    
    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// User.
    /// </summary>
    public class WebPrivilege : WebEntity{

        [ApiMember(Name = "operation", Description = "Privilege operation", ParameterType = "query", DataType = "string", IsRequired = false)]
        public string Operation { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Terradue.Tep.WebServer.WebPrivilege"/> class.
        /// </summary>
        public WebPrivilege() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Terradue.Tep.WebServer.WebPrivilege"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebPrivilege(Privilege entity) : base(entity) {
            this.Operation = entity.OperationChar;
        }

        /// <summary>
        /// Tos the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
        public Privilege ToEntity(IfyContext context, Privilege input) {
            Privilege privilege = input ?? new Privilege (context);
            privilege.Identifier = this.Identifier;
            privilege.Name = this.Name;
            privilege.OperationChar = Operation;

            return privilege;
        }
            
    }
}

