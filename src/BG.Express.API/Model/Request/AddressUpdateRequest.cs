using System.ComponentModel.DataAnnotations;

namespace BG.Express.API.Model.Request
{
    public class AddressUpdateRequest 
    {
        [Required]
        public string AddressText { get; set; }
        [Required]
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string AddressType { get; set; }
    }
}
