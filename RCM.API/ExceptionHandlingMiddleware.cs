using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RCM.Common.Exception;
using RCM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(DomainNotFoundException ex)
            { 
                _logger.LogError(ex.ToString());

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                }.ToString());
            }
            catch (DomainValidationException ex)
            {   
                _logger.LogError(ex.ToString());

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message =ex.Message
                }.ToString());


            } 
 
            catch (Exception ex)
            {
                 

                _logger.LogError(ex.ToString());

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An internal Server error occured. Please try again later."
                }.ToString());

                 
            }
        }
    }
}
