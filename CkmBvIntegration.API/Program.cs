using CkmBvIntegration.API.Filters.OperationFilter.AuthenticationFilter;
using CkmBvIntegration.API.Filters.Schemas.AuthenticationFilter;
using CkmBvIntegration.Application.AutoMapper;
using CkmBvIntegration.Application.DependencyInjection;
using CkmBvIntegration.Domain.Exceptions.Models;
using CkmBvIntegration.Domain.Models.HttpClientSettings;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region Initialize Applications and Repositories
builder.Services.ConfigureServices(builder.Configuration);
#endregion

#region ConfigureMessages
builder.Services.Configure<AuthenticationExceptions>(builder.Configuration.GetSection("ExceptionMessages"));
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(ApiMappingProfile));
#endregion

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<AuthenticationFilterSchema>();
    options.OperationFilter<AuthenticationOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
