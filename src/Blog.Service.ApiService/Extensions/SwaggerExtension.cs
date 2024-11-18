using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Blog.Service.ApiService.Extensions;

public static class SwaggerExtension
{
    
    /// <summary>
    /// swagger 配置
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection Swagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Blog", Version = "v1", Contact = new OpenApiContact
                {
                    Name  = "青山",
                    Email = "2824593349@qq.com"
                }
            });
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "API Key needed to access the endpoints. Example: \"Authorization: {key}\"",
                Name        = "Authorization",
                In          = ParameterLocation.Header,
                Type        = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id   = "ApiKey"
                        },
                        Name = "Authorization",
                        In   = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
            // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            //c.SchemaFilter<MySchemaFilter>();
            // 获取XML文档文件路径
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            // 添加XML文档注释
            c.IncludeXmlComments(xmlPath);
        });
        return service;
    }
}