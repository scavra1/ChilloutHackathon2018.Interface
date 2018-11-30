using InterfaceModels.User;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChilloutHackathon2018.Creator.ApiConection
{
    class UserContext : ApiContext
    {
        public UserInfo Login(UserCredentials credentials)
        {
            var request = new RestRequest("users/userexists", Method.POST);
            request.AddJsonBody(credentials);

            var response = client.Execute<UserInfo>(request);

            return response.Data;
        }
    }
}
