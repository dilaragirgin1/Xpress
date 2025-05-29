using System.Collections.Generic;

namespace BG.Express.API.Model.Response
{
    
    public class GetGeocodesResponse
    {
        public List<GeocodeWarning> GeocodeWarnings { get; set; }
        public int GeocodeCount { get; set; }
        public List<GeocodedLocation> GeocodedLocations { get; set; }
        public List<InputError> InputErrors { get; set; }
    }


    public class InputError
    {
        public string Error { get; set; }
        public string Detail { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}  {1}", Error, Value);
        }
    }

    public class GeocodeWarning
    {
        public string SuggestedCity { get; set; }
        public string GeocoderAddress { get; set; }
        public string SuggestedCounty { get; set; }
        public double Longitude { get; set; }
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public string LocationId { get; set; }
        public string LocationAddress { get; set; }
        public float GeocodeScore { get; set; }
    }

    public class GeocodedLocation
    {
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string LocationId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }


}
