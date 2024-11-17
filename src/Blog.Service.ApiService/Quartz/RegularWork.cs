using Quartz;

namespace Blog.Service.ApiService.Quartz;

public class RegularWork : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        return Task.Run(() =>
        {
            Console.WriteLine(DateTime.Now + "Quartz");
        });
    }
}