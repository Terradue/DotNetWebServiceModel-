using System;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.ServiceInterface;
using Terradue.Portal;

namespace Terradue.WebService.Model {

    [Route("/group/{id}", "GET", Summary = "GET the group", Notes = "Group is found from id")]
    public class GetGroup : IReturn<WebGroup> {
        [ApiMember(Name = "id", Description = "Group id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/group", "GET", Summary = "GET a list of groups", Notes = "")]
    public class GetGroups : IReturn<List<WebGroup>> {
    }

    [Route("/group", "PUT", Summary = "Update group", Notes = "")]
    public class UpdateGroup : WebGroup, IReturn<WebGroup> {}

    [Route("/group", "POST", Summary = "Create a new group", Notes = "Group is contained in the POST data.")]
    public class CreateGroup : WebGroup, IReturn<WebGroup> {}

    [Route("/group/{grpId}/user", "POST", Summary = "Add user to group", Notes = "User is contained in the POST data.")]
    public class AddUserToGroup : WebUser, IReturn<WebGroup> {
        [ApiMember(Name = "grpId", Description = "Group id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int GrpId { get; set; }
    }

    [Route("/group/{grpId}/user", "GET", Summary = "Get users from group", Notes = "")]
    public class GetUsersFromGroup : IReturn<List<WebGroup>> {
        [ApiMember(Name = "grpId", Description = "Group id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int GrpId { get; set; }
    }

    [Route("/group/{grpId}/user", "PUT", Summary = "Save exaclty user to group", Notes = "Users are contained in the PUT data.")]
    public class SaveExacltyUsersToGroup : List<WebUser>, IReturn<WebGroup> {
        [ApiMember(Name = "grpId", Description = "Group id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int GrpId { get; set; }
    }

    [Route("/group/{grpId}/user/{usrId}", "DELETE", Summary = "Delete user from group", Notes = "Group is contained in the POST data.")]
    public class RemoveUserFromGroup : IReturn<WebGroup> {
        [ApiMember(Name = "grpId", Description = "Group id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int GrpId{ get; set; }
        [ApiMember(Name = "usrId", Description = "User id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int UsrId { get; set; }
    }

    [Route("/group/{id}", "DELETE", Summary = "Remove group", Notes = "Group is found via Id")]
    public class DeleteGroup : IReturn<WebResponseBool> {
        [ApiMember(Name = "id", Description = "Group id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// WebGroup.
    /// </summary>
    public class WebGroup : WebEntity{

        [ApiMember(Name = "Description", Description = "Group description", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Description { get; set; }

        [ApiMember(Name = "Priority", Description = "Group priority", ParameterType = "query", DataType = "int", IsRequired = false)]
        public int Priority { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.WebGroup"/> class.
        /// </summary>
        public WebGroup() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.WebGroup"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebGroup(Group entity) : base(entity) {
            this.Identifier = entity.Identifier;
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Priority = entity.Priority;
        }

        /// <summary>
        /// Tos the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
		public Group ToEntity(IfyContext context, Group input) {
            Group grp = (input == null ? new Group(context) : input);

            grp.Name = this.Name;
            grp.Description = this.Description;
            grp.Priority = this.Priority;
           
            return grp;
        }
            
    }
}

