namespace BG.Express.API.Model.Response
{
    public class DriverGetAllResponse
    {
        public string Id { get; set; }
        public string DriverName { get; set; }
        public string DriverImage { get; set; }
        public string DriverPhone { get; set; }
        public bool IsActive { get; set; }
    }
}
