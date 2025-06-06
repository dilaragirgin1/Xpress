using System.Collections.Generic;
using System.Linq;

namespace BG.Express.API.Model.Response
{
    public class BaseResponse<TData>
    {
        public BaseResponse()
        {
            Errors = new List<string>();
        }

        public bool HasError => Errors.Any();
        public List<string> Errors { get; set; }
        public long Total { get; set; }
        public TData Data { get; set; }
    }
}
