using Filmes.Api.Extensions;
using Filmes.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

#region Extensions

SwaggerExtension.AddSwagger(builder);
EntityFrameworkExtension.AddEntityFramework(builder);
CorsExtension.AddCors(builder);

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

CorsExtension.UseCors(app);

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
