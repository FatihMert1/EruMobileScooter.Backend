using EruMobileScooter.Api.Models;

namespace EruMobileScooter.Api.Helpers
{
    public static class ResponseHelper
    {
        
        public static ApiResponse<T> CreateResponse<T>(T data, string message, int statusCode, bool error){
            return new ApiResponse<T>{
                Data=data, Message = message, StatusCode = statusCode, Error = error
            };
        }
    }
}