using System.Net;

namespace ApplicationFormAPI.Common
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int? TotalCount { get; set; }
        public object Data { get; set; }

        public static APIResponse GetFailureMessage(HttpStatusCode statusCode, object data, string msg)
        {
            var failedResponse = new APIResponse()
            {
                StatusCode = statusCode,
                Data = data,
                Message = msg,
                Success = false
            };

            return failedResponse;
        }

        public static APIResponse GetSuccessMessage(HttpStatusCode statusCode, object data, string msg, int count = 0)
        {
            var successResponse = new APIResponse()
            {
                StatusCode = statusCode,
                Data = data,
                Message = msg,
                Success = true,
                TotalCount = count
            };

            return successResponse;
        }
    }
}
