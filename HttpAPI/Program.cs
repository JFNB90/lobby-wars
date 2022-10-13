using HttpAPI.Extensions;
using HttpAPI.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseEndpointsAPIMiddleware(app);

//app.UseExceptionHandler(exceptionHandlerApp =>
//{
//    exceptionHandlerApp.Run(async context =>
//    {
//        int k = 0;
        //context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        //// using static System.Net.Mime.MediaTypeNames;
        //context.Response.ContentType = Text.Plain;

        //await context.Response.WriteAsync("An exception was thrown.");

        //var exceptionHandlerPathFeature =
        //    context.Features.Get<IExceptionHandlerPathFeature>();

        //if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
        //{
        //    await context.Response.WriteAsync(" The file was not found.");
        //}

        //if (exceptionHandlerPathFeature?.Path == "/")
        //{
        //    await context.Response.WriteAsync(" Page: Home.");
        //}
//    });
//});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}