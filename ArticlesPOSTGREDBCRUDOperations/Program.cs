using ArticlesPOSTGREDBCRUDOperations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisteredServices(builder.Configuration);

var app = builder.Build();

app.UseCustomMiddleware();

app.Run();
