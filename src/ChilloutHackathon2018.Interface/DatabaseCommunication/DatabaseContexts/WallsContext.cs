using System;
using System.Collections.Generic;
using DatabaseCommunication.Queries;
using InterfaceModels.Wall;

namespace DatabaseCommunication.DatabaseContexts
{
    public class WallsContext : DatabaseContext
    {
        public WallsContext() : base()
        {
        }

        public void UpdateModel(WallModel wallModel)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("UserID", wallModel.UserID);
            parameters.Add("Details", wallModel.Details);
            parameters.Add("MarkerID", 0);

            Execute(WallQueries.UpdateModel, parameters);
        }

        public WallModel GetModelByUserId(long userId)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("UserID", userId);

            return QueryFirstOrDefault<WallModel>(WallQueries.GetModelByUserId, parameters);
        }

        //public WallModel GetModelByUserId(long modelId)
        //{
        //    var parameters = new Dictionary<string, object>();

        //    parameters.Add()
        //}
    }
}
