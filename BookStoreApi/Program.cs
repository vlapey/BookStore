using BookStoreApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence();
builder.Services.ConfigureServices();

builder.Services.AddControllers();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureAutoMapper();

var app = builder.Build();

app.ConfigureSwaggerWebApplication();
app.ConfigureWebApplication();