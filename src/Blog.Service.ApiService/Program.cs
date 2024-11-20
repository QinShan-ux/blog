using Blog.Service.ApiService.Extensions;
using Blog.Service.ApiService.Middle;
using Blog.Service.ApiService.Quartz;
using Blog.Service.Common.DBContect;
using Mapster;
using MapsterMapper;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, sp, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
    .ReadFrom.Services(sp) 
    .Enrich.FromLogContext()
    .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
    .WriteTo.File("D:\\网站发布\\log.txt"))
    ;

// Add services to the container.
// 定时任务
// builder.Host.Quartz();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// swagger 配置
builder.Services.Swagger();
// 将 配置文件中的 SqlOptions 绑定到SqlOptions实体
builder.Services.Configure<SqlOptions>(builder.Configuration.GetSection("SqlOptions"));
// 配置mapper 映射
builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddTransient<RegularWork>();
builder.Services.AddScoped<IMapper, ServiceMapper>();
// 注入数据库连接
builder.Services.AddScoped<DbContext>();
builder.Services.CreateService();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
Console.WriteLine(AppContext.BaseDirectory);
app.Run();