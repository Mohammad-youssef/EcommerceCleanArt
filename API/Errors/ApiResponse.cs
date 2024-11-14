
namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message =null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        } 
        public  int StatusCode { get; set; }
        public  string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad Request",
                401 => "Authorization Error",
                404 => "Resource Not Found",
                500 => "Internal Server Error",
                _ => null

            };
        }

    }
}
