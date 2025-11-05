using static Apple.Web.Utility.StaticDetail;

namespace Apple.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.Get;
        public string Url { get; set; } = null!;
        public object Data { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
    }
}