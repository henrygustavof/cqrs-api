﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;
using Project.API.Response;

namespace Project.API.Middleware
{
    public class ErrorMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            string errorMessage = string.Empty;
            try
            {
                await _next.Invoke(context);
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                _logger.LogError(ex, ex.Message);

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError(ex, ex.Message);

            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var response = new ErrorResponse(context.Response.StatusCode, errorMessage);

                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
