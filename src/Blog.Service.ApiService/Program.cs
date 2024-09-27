using System.Reflection;
using Blog.Service.ApiService.Extensions;
using Blog.Service.ApiService.Middlewear;
using Blog.Service.Common.DBContect;
using Blog.Service.Core.Memory;
using Blog.Service.Core.Plan;
using Blog.Service.Core.Sentence;
using Mapster;
using MapsterMapper;
using Microsoft.OpenApi.Models;
using Quartz;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, sp, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
    .ReadFrom.Services(sp) 
    .Enrich.FromLogContext()
    .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen));
// Add services to the container.
builder.Host.ConfigureServices((ctx, service) =>
{
    service.AddQuartz();
    service.AddQuartzHostedService(opt =>
    {
        opt.WaitForJobsToComplete = true;
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog", Version = "v1",Contact = new OpenApiContact
    {
        Name = "青山",
        Email = "2824593349@qq.com"
    }});
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key needed to access the endpoints. Example: \"Authorization: {key}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                Name = "Authorization",
                In = ParameterLocation.Header,
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
    Console.WriteLine(AppContext.BaseDirectory + "---");
    // 添加XML文档注释
    c.IncludeXmlComments(xmlPath);
    c.IncludeXmlComments("D:\\Programme Project\\.net\\demo01\\Blog\\src\\Blog.Service.Model\\Blog.Service.Model.xml");
    
});

// 配置mapper 映射
builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// 注入数据库连接
builder.Services.AddScoped<DbContext>();
// 注入service
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IMemoryService, MemoryService>();
builder.Services.AddScoped<ISentenceService, SentenceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1"); });

}
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();
// 使用全局异常处理中间件
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();