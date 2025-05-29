using System.ComponentModel.DataAnnotations;

namespace BG.Express.API.Model.Request
{
    public class AddressCreateRequest
    {
        [Required]
        public string CustomerCode { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        public int CityCode { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
