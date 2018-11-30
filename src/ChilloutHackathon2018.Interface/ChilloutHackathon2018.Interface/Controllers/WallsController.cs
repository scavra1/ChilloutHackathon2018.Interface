using DatabaseCommunication.DatabaseContexts;
using InterfaceModels.Wall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChilloutHackathon2018.Interface.Controllers
{
    public class WallsController : ApiController
    {
        private WallsContext wallsContext;
        public WallsController()
        {
            wallsContext = new WallsContext();
        }

        [HttpPost]
        public void UpdateModel(WallModel wallModel)
        {
            wallsContext.UpdateModel(wallModel);
        }

        [HttpGet]
        public WallModel GetUserWallModel(long userId)
        {
            return wallsContext.GetModelByUserId(userId);
        }
    }
}
