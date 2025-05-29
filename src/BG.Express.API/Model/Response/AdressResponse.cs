
namespace BG.Express.API.Model.Response
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string StreetAddress { get; set; }
        public int CityCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsError { get; set; }
    }
}
