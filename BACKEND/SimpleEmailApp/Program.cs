using Microsoft.AspNetCore.Mvc;
using SimpleEmailApp.Controllers;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200", "http://localhost:4200/reset-credentials") 
            
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials(); 
});


app.Use(async (context, next) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200,http://localhost:4200/reset-credentials");
        context.Response.Headers.Add("Access-Control-Allow-Methods", "POST");
        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
        context.Response.StatusCode = 204; 
    }
    else
    {
        await next();
    }
});






app.Run();

