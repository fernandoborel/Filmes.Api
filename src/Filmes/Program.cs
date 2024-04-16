using Filmes.Api.Extensions;
using System.Text.Json.Serialization;
//using Filmes.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

#region Extensions

SwaggerExtension.AddSwagger(builder);
EntityFrameworkExtension.AddEntityFramework(builder);
CorsExtension.AddCors(builder);
JwtExtension.AddJwtBearerSecurity(builder);

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

CorsExtension.UseCors(app);

//comentei essa parte para realizar novos testes, após testes descomentar
//app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
