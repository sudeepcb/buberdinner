using BuberDinner.Api;
using BuberDinner.Api.Middleware;
using BuberDinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using static BuberDinner.Application.DependencyInjection;
using static BuberDinner.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddInfrastructure(builder.Configuration)
        .AddPresentation()
        .AddApplication();

    /*
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ErrorHandlingFilterAttribute>();
    });
    */
} 

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    /*
    app.Map("/error", (HttpContext httpContext) => {
        Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Results.Problem();
    });
    */
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

