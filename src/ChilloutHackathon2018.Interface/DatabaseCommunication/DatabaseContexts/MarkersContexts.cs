namespace DatabaseCommunication.DatabaseContexts
{
    using DatabaseCommunication.Queries;
    using InterfaceModels.Marker;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 'Markers' table methods
    /// </summary>
    public class MarkerContext : DatabaseContext
    {
        public MarkerContext() : base()
        {

        }

        public List<MarkerModel> GetMarkersByUserId(long userId)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("UserID", userId);

            return Query<MarkerModel>(MarkerQueries.GetMarkersByUserID, parameters);
        }

        public long AddUserMarker(MarkerModel userMarker)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("UserID", 1);
            parameters.Add("Picture", userMarker.Picture);
            parameters.Add("ModelID", userMarker.ModelID);

            return ExecuteScalar<long>(MarkerQueries.AddUserMarker, parameters);
        }

        public void DeleteUserMarker(long markerId)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("MarkerID", markerId);

            Execute(MarkerQueries.DeleteMarker, parameters);
        }

        public void UpdateMarkerModelReference(MarkerModel markerModel)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("MarkerID", markerModel.MarkerID);
            parameters.Add("ModelID", markerModel.ModelID);


            Execute(MarkerQueries.UpdateMarkerModelReference, parameters);
        }

        public void UpdateMarkerImage(MarkerModel markerModel)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("MarkerID", markerModel.MarkerID);
            parameters.Add("Picture", markerModel.Picture);

            Execute(MarkerQueries.UpdateMarkerImage, parameters);
        }




        //public object AddUserMarker(MarkerModel userMarker)
        //{
        //    var parameters = new Dictionary<string, object>()
        //    {
        //        new KeyValuePair("")
        //    }

        //}
    }
}
