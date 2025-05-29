namespace BG.Express.API.Model.Request
{
    public class GetAddressRequest : PagedBaseRequest
    {
        public string? CustomerCode { get; set; }
        public string? City { get; set; }
        public int? CityCode { get; set; }
        public bool IsError { get; set; }

    }
}