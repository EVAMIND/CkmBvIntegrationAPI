using CkmBvIntegration.API.Filters.OperationFilter.AuthenticationFilter;
using CkmBvIntegration.API.Filters.Schemas.AuthenticationFilter;
using CkmBvIntegration.Application.AutoMapper;
using CkmBvIntegration.Application.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CkmAuthorizationTools.AuthenticationServices.Extensions;
using CkmAuthorizationTools.AuthorizationServices.Extensions;
using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.API.Extensions;
using CkmBVIntegration.API.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
var Services = builder.Services;

#region Initialize Applications and Repositories
Services.ConfigureServices(builder.Configuration);
Services.AddSingleton<AuthenticationResponse>();
#endregion

#region AutoMapper
Services.AddAutoMapper(typeof(ApiMappingProfile));
Services.AddAutoMapper(typeof(AplicationMappingProfile));


#endregion

Services.AddCustomAuthentication(Configuration);
Services.AddCustomAuthorization(await Services.GetApplicationPermissions(Configuration)!);
Services.AddCustomApiAuthorizationHandler();

//Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//   .AddJwtBearer(options =>
//   {
//       options.Authority = "https://your-identity-server";
//       options.TokenValidationParameters = new TokenValidationParameters
//       {
//           ValidateAudience = false
//       };
//   });
// Add services to the container.
Services.AddControllers();
Services.AddHttpClient();


#region Swagger 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<AuthenticationFilterSchema>();
    options.OperationFilter<AuthenticationOperationFilter>();

    options.SchemaFilter<ProposalFilterSchema>();
    options.OperationFilter<ProposalOperationFilter>();  
    
    options.SchemaFilter<ProposalStatusFilterSchema>();
    options.OperationFilter<ProposalStatusOperationFilter>(); 
    
    options.SchemaFilter<PDECOfferFilterSchema>();
    options.OperationFilter<PDECOfferOperationFilter>();
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

app.UseAuthentication();

app.MapControllers();

app.Run();
