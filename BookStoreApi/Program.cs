using BookStoreApi;
using BookStoreApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence();
builder.Services.ConfigureServices();

builder.Services.Configure<ClownStringsModel>(builder.Configuration.GetSection(ClownStringsModel.SectionName));
builder.Services.AddControllers();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureAutoMapper();

var app = builder.Build();

app.ConfigureSwaggerWebApplication();
app.ConfigureWebApplication();