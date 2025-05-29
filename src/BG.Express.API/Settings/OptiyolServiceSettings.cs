using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BG.Express.API.Settings
{
    public class OptiyolServiceSettings
    {
        public string ApiUrl { get; set; }
        public int Timeout { get; set; }
        public string Token { get; set; }
        public int CompanyId { get; set; }
    }
}
