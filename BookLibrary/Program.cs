using BookLibrary.Extensions;
using BookLibrary.Middleware;
using Contracts;
using MediatR;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureIisIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(config => 
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddApplicationPart(typeof(BookLibrary.Presentation.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


var logger = app.Services.GetRequiredService<ILoggerManager>();
var prefix = app.Configuration.GetSection("Prefix").Value;

app.UseMiddleware<GlobalRoutePrefixMiddleware>(prefix);
app.UsePathBase(new PathString(prefix));

app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
    app.UseHsts();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();