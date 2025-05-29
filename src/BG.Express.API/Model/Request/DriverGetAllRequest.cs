using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BG.Express.API.Model.Request
{
    public class DriverGetAllRequest
    {
        public DriverGetAllRequest()
        {
            this.Ids = new List<string>();
        }
        public string Id { get; set; }
        public List<string> Ids { get; set; }
        public bool? IsActive { get; set; }
    }
}
