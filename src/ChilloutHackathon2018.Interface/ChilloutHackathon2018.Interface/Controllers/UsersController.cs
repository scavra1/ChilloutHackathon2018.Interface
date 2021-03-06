﻿namespace ChilloutHackathon2018.Interface.Controllers
{
    using DatabaseCommunication.DatabaseContexts;
    using InterfaceModels.User;
    using System.Web.Http;

    public class UsersController : ApiController
    {
        private UserContext userContext;

        public UsersController() : base()
        {
            userContext = new UserContext();
        }

        [HttpGet]
        public int Get()
        {
            return 42424;
        }

        [HttpPost]
        public UserInfo UserExists([FromBody] UserCredentials credentials)
        {
           var foundUser = userContext.FindUser(credentials);

            if(foundUser == null)
            {
                return new UserInfo();
            }

            return foundUser;
        }
    }
}