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

//builder.Services.AddAuthentication(options =>
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
