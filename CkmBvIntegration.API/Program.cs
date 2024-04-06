using CkmBvIntegration.API.Filters.OperationFilter.AuthenticationFilter;
using CkmBvIntegration.API.Filters.Schemas.AuthenticationFilter;
using CkmBvIntegration.Application.AutoMapper;
using CkmBvIntegration.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

#region Initialize Applications and Repositories
builder.Services.ConfigureServices(builder.Configuration);
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(ApiMappingProfile));
#endregion

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();

#region Swagger 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<AuthenticationFilterSchema>();
    options.OperationFilter<AuthenticationOperationFilter>();

    options.SchemaFilter<ProposalFilterSchema>();
    options.OperationFilter<ProposalOperationFilter>();
});
#endregion

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
