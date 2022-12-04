﻿using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    //Hangi middleware'i kullanacaksın?
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}