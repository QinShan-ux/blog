using Blog.Service.Core.Memory;
using Blog.Service.Core.Plan;
using Blog.Service.Core.Sentence;

namespace Blog.Service.ApiService.Extensions;
/// <summary>
/// service 扩展
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// 注册业务service
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection CreateService(this IServiceCollection service)
    {
        service.AddScoped<IPlanService, PlanService>();
        service.AddScoped<IMemoryService, MemoryService>();
        service.AddScoped<ISentenceService, SentenceService>();
        return service;
    }
}