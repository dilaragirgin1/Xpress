using System.ComponentModel.DataAnnotations;

namespace BG.Express.API.Data.Entity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerCode { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
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
        public bool IsError { get; set; }
        public float GeocodeScore { get; set; }        
        public string WarningMessage { get; internal set; }



    }
}
