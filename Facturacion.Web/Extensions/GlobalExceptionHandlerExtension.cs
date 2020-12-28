using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Facturacion.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Facturacion.Web.Extensions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, ILogger logger,
            string errorPagePath, bool respondWithJsonErrorDetails = false)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var jsonSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = null
                        }
                    };
                    var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionFeature.Error;
                    var path = exceptionFeature.Path;
                    var guid = Guid.NewGuid().ToString();

                    var errorDetails = $@"{exception.Message}
                                         {Environment.NewLine}
                                         {exception.StackTrace}";

                    var statusCode = (int)HttpStatusCode.OK;

                    context.Response.StatusCode = statusCode;

                    var message = "Sorry something went wrong on the server. Contact support with the following code: " + guid;
                    var problemDetails = new CommonResponse<ErrorDetails>
                    {
                        Message = message,
                        Status = CommonResponseTypeStatus.error.ToString(),
                        Data = new ErrorDetails
                        {
                            Id = guid,
                            ErrorMessage = exception.Message,
                            StackTrace = exception.StackTrace
                        }
                    };

                    var json = JsonConvert.SerializeObject(problemDetails, jsonSettings);

                    //============================================================
                    //Log Exception
                    //============================================================
                    logger.LogError(exception, "{guid}", guid);

                    //============================================================
                    //Return response
                    //============================================================
                    var matchText = "JSON";

                    var requiresJsonResponse = context.Request
                                                        .GetTypedHeaders()
                                                        .Accept
                                                        .Any(t => t.Suffix.Value?.ToUpper() == matchText
                                                                  || t.SubTypeWithoutSuffix.Value?.ToUpper() == matchText);

                    if (requiresJsonResponse)
                    {
                        context.Response.ContentType = "application/json; charset=utf-8";
                        if (!respondWithJsonErrorDetails)
                            json = JsonConvert.SerializeObject(new CommonResponse<ErrorDetails>
                            {
                                Message = message,
                                Status = CommonResponseTypeStatus.error.ToString(),
                                Data = new ErrorDetails
                                {
                                    Id = guid,
                                    ErrorMessage = string.Empty,
                                    StackTrace = string.Empty
                                }
                            }, jsonSettings);
                        await context.Response
                                        .WriteAsync(json, Encoding.UTF8);
                    }
                    else
                    {
                        //TODO: enviar codigo de error
                        context.Items["isVerified"] = true;
                        context.Response.Redirect(errorPagePath);

                        await Task.CompletedTask;
                    }
                });
            });
        }
    }
}
