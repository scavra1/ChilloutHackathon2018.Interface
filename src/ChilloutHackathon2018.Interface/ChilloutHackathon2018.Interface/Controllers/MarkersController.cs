namespace ChilloutHackathon2018.Interface.Controllers
{
    using DatabaseCommunication.DatabaseContexts;
    using InterfaceModels.Marker;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// Markers
    /// </summary>
    public class MarkersController : ApiController
    {
        private MarkerContext markersContext;

        public MarkersController() : base()
        {
            markersContext = new MarkerContext();
        }

        /// <summary>
        ///  Gets all markers assigned to specific user.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of user's markers</returns>
        [HttpGet]
        public List<MarkerModel> GetUsersMarkers(long userId)
        {
            return markersContext.GetMarkersByUserId(userId);
        }


        [HttpPost]
        public long AddUserMarker(MarkerModel userMarker)
        {
            return markersContext.AddUserMarker(userMarker);
        }

        [HttpPost]
        public void UpdateMarkerImage(MarkerModel markerModel)
        {
            markersContext.UpdateMarkerImage(markerModel);
        }

        [HttpPost]
        public void UpdateMarkerModelReference(MarkerModel markerModel)
        {
            markersContext.UpdateMarkerModelReference(markerModel);
        }

        [HttpDelete]
        public void DeleteUserMarker(long markerId)
        {
            markersContext.DeleteUserMarker(markerId);
        }
    }


}
