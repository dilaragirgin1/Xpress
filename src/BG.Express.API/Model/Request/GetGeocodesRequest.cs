using System.Collections.Generic;

namespace BG.Express.API.Model.Request
{
    public class GetGeocodesRequest
    {
        public GetGeocodesRequest()
        {
            this.Locations = new List<Location>();
        }
        public List<Location> Locations { get; set; }
        public int Company_Id { get; set; }
    }

    public class Location
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string District { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsVerified { get; set; }
    }
}
