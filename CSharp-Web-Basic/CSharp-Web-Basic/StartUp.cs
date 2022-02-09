using MyWebServer.Server;
using MyWebServer.Server.Responses;
using System.Threading.Tasks;
using System;
using CSharp_Web_Basic.Controllers;

public class StartUp
{
    public static async Task Main()
        => await new HTTPServer(routers => routers
            .MapGet("/", request => new HomeController(request).Index())
            .MapGet("/Softuni", request => new HomeController(request).ToSoftUni())
            .MapGet("toCats", request => new HomeController(request).LocalRedirect())
            .MapGet("/Cats", request => new AnimalsController(request).Cats())
            .MapGet("/Dogs", request => new AnimalsController(request).Dogs())
            .MapGet("/Rabbits", request => new AnimalsController(request).Bunnies())
            .MapGet("/Turtles", request => new AnimalsController(request).Turtles())
            .MapGet("/CreateCat", request => new CatsController(request).CreateCat())
            .MapPost("/Cats/Save", request => new CatsController(request).Save()))
        .Start();
}