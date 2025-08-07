using System.Reflection;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GPBATestTask.Api;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
            _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"GPBA test task {apiVersion}",
                        Description = "Web api for working with offers and providers.",
                        //TermsOfService = new Uri(""),
                        Contact = new OpenApiContact
                        {
                            Name = "Andrey Zozuk (developer)",
                            Email = "",
                            Url = new Uri("https://t.me/andrey_zozuk")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "My license.",
                            //Url = new Uri("")
                        }
                    });

                options.CustomOperationIds(apiDescription =>
                    apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : null);
            }
        }
    }