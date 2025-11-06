namespace Apple.Web.Utility
{
    public class StaticDetail
    {
        public static string? CouponApiBaseUrl { get; set; }
        public enum ApiType
        {
            Get,
            Post,
            Put,
            Delete
        }
    }
}