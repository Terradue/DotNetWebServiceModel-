using System;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.ServiceInterface;
using Terradue.Portal;
using ServiceStack.Common.Web;

namespace Terradue.WebService.Model {

    [Route("/user/{id}", "GET", Summary = "GET the user", Notes = "User is found from id")]
    public class GetUser : IReturn<WebUser> {
        [ApiMember(Name = "id", Description = "User id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/user/current", "GET", Summary = "GET the current user", Notes = "User is the current user")]
    public class GetCurrentUser : IReturn<WebUser> {}

    [Route("/user/search", "GET", Summary = "GET user as opensearch", Notes = "")]
    public class UserSearchRequest : IReturn<HttpResult> { }

    [Route("/user/description", "GET", Summary = "GET user as opensearch", Notes = "")]
    public class UserDescriptionRequestTep : IReturn<HttpResult> { }

    [Route("/user", "GET", Summary = "GET a list of users", Notes = "Users can be filtered by Group")]
    public class GetUsers : IReturn<List<WebUser>> {
        [ApiMember(Name = "Group", Description = "Group Name", ParameterType = "path", DataType = "String", IsRequired = false)]
        public String Group { get; set; }
    }

    [Route("/user", "PUT", Summary = "Update user", Notes = "User is contained in the PUT data. Only non UMSSO data can be updated, e.g redmineApiKey or certField")]
    public class UpdateUser : WebUser, IReturn<WebUser> {}

    [Route("/user", "POST", Summary = "Create a new user", Notes = "User is contained in the POST data.")]
    public class CreateUser : WebUser, IReturn<WebUser> {}

    [Route("/user/{id}", "DELETE", Summary = "Remove user", Notes = "User is found via Id")]
    public class DeleteUser : IReturn<WebUser> {
        [ApiMember(Name = "id", Description = "User id", ParameterType = "query", DataType = "int", IsRequired = true)]
        public int Id { get; set; }
    }

    [Route("/user/emailconfirm", "POST", Summary = "Ask for confirmation email", Notes = "User is found with auth")]
    public class SendUserEmailConfirmationEmail : IReturn<WebUser> {
    }

    [Route("/user/emailconfirm", "GET", Summary = "Confirm email", Notes = "User is found with auth")]
    public class ConfirmUserEmail : IReturn<WebUser> {
        [ApiMember(Name = "token", Description = "confirmation key", ParameterType = "query", DataType = "string", IsRequired = true)]
        public string Token { get; set; }
    }

    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// User.
    /// </summary>
    public class WebUser : WebEntity{

        [ApiMember(Name = "UserName", Description = "User short name", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Username { get; set; }

        [ApiMember(Name = "Firstname", Description = "User first name", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String FirstName { get; set; }

        [ApiMember(Name = "Lastname", Description = "User last name", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String LastName { get; set; }

        [ApiMember(Name = "Password", Description = "User password", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Password { get; set; }

        [ApiMember(Name = "Email", Description = "User email", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Email { get; set; }

        [ApiMember(Name = "Affiliation", Description = "User organization name", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Affiliation { get; set; }

        [ApiMember(Name = "Country", Description = "User Country", ParameterType = "query", DataType = "String", IsRequired = false)]
        public String Country { get; set; }

        [ApiMember(Name = "Level", Description = "User level", ParameterType = "query", DataType = "int", IsRequired = false)]
        public int Level { get; set; }

        [ApiMember(Name = "AccountStatus", Description = "User Account Status", ParameterType = "query", DataType = "int", IsRequired = false)]
        public int AccountStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.Metadata.Model.User"/> class.
        /// </summary>
        public WebUser() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.WebService.Model.User"/> class.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public WebUser(User entity) : base(entity) {
            this.Username = entity.Username;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.Email = entity.Email;
            this.Affiliation = entity.Affiliation;
            this.Country = entity.Country;
            this.Level = entity.Level;
            this.AccountStatus = entity.AccountStatus;
        }

        /// <summary>
        /// Tos the entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="context">Context.</param>
		public User ToEntity(IfyContext context, User input) {
			User user = (input == null ? new User(context) : input);

            user.Identifier = this.Identifier;
            user.Name = this.Name;
            user.Username = this.Username;
            user.FirstName = this.FirstName;
            user.LastName = this.LastName;
            user.Email = this.Email;
            user.Affiliation = this.Affiliation;
            user.Country = this.Country;
            user.Level = this.Level;
            user.AccountStatus = this.AccountStatus;

            return user;
        }
            
    }
}

