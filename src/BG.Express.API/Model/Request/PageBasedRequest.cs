using System.ComponentModel.DataAnnotations;

namespace BG.Express.API.Model.Request
{
    public abstract class PagedBaseRequest
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public string SortBy { get; set; }
        public SortOrder SortOrder { get; set; }
    }

    public enum SortOrder
    {
        Asc,
        Desc
    }
}