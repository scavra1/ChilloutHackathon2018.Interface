using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChilloutHackathon2018.Creator.ApiConection
{
    public class ApiContext
    {
        public ApiContext()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ApiAddress"]);
        }

        protected RestClient client;
    }
}
