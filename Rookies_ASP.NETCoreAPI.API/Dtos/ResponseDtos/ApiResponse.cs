namespace Rookies_ASP.NETCoreAPI.API.Dtos.ResponseDtos
{
    public class ApiResponse
    {
        public object Data { get; set; } = new { };

        public int StatusCode { get; set; } = StatusCodes.Status200OK;

        public string Message { get; set; } = string.Empty;

    }
}
