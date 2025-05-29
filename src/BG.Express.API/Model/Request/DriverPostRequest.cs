using System.ComponentModel.DataAnnotations;

namespace BG.Express.API.Model.Request
{
    public class DriverPostRequest
    {
        public string DriverName { get; set; }
        public string DriverImage { get; set; }
        public string DriverPhone { get; set; }
        public bool IsActive { get; set; }
    }
}
