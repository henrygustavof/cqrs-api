using Project.API.Constants;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Project.API.Response
{
    public class ErrorResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = string.IsNullOrEmpty(message) ? GetDefaultMessageForStatusCode(statusCode) : message;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case StatusCodes.Status400BadRequest:
                    return HttErrorResponseConstants.Status400BadRequest;
                case StatusCodes.Status401Unauthorized:
                    return HttErrorResponseConstants.Status401Unauthorized;
                case StatusCodes.Status403Forbidden:
                    return HttErrorResponseConstants.Status403Forbidden;
                case StatusCodes.Status404NotFound:
                    return HttErrorResponseConstants.Status404NotFound;
                case StatusCodes.Status415UnsupportedMediaType:
                    return HttErrorResponseConstants.Status415UnsupportedMediaType;
                case StatusCodes.Status500InternalServerError:
                    return HttErrorResponseConstants.Status500InternalServerError;
                default:
                    return HttErrorResponseConstants.StatusDefaultError;
            }
        }
    }
}
