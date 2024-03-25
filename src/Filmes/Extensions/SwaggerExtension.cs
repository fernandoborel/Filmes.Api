using Microsoft.OpenApi.Models;

namespace Filmes.Api.Extensions;

public class SwaggerExtension
{
    public static void AddSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Filmes API",
                Version = "v1",
                Description = "API de Filmes",
                Contact = new OpenApiContact
                {
                    Name = "Fernando Borel",
                    Email = "fernandomenezesborel@gmail.com",
                    Url = new Uri("https://github.com/fernandoborel")
                }
            });
        });
    }
}
