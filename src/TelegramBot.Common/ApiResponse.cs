using JetBrains.Annotations;

namespace TelegramBot.Common
{
    [PublicAPI]
    public class ApiResponse
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public static ApiResponse Ok()
        {
            return new ApiResponse
            {
                Success = true
            };
        }

        public static ApiResponse<T> Ok<T>(T result) where T : class
        {
            return new ApiResponse<T>
            {
                Success = true,
                Result = result
            };
        }

        public static ApiResponse Fail(string message)
        {
            return new ApiResponse
            {
                Success = false,
                Error = message
            };
        }

        public static ApiResponse<T> Fail<T>(string message) where T : class
        {
            return new ApiResponse<T>
            {
                Success = false,
                Error = message
            };
        }
    }

    public class ApiResponse<T> : ApiResponse where T : class
    {
        public T Result { get; set; }
    }
}
