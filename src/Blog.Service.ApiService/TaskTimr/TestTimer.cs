using System.Timers;
using Blog.Service.Core.Sentence;
using Flurl;
using Flurl.Http;
using Timer = System.Timers.Timer;

namespace Blog.Service.ApiService.TaskTimr;

public class TestTimer
{
    
    /// <summary>
    /// 时间间隔
    /// </summary>
    public static int Interval = 10000;
    /// <summary>
    /// 执行多少次
    /// </summary>
    public static bool Auto     = true;

    public static void InitInterval()
    {
        DateTime time = DateTime.Now;
        DateTime end  = new DateTime(time.Year, time.Month, time.Day,time.Hour,time.Minute + 1,time.Second);
        TimeSpan ts   = end - time;
        Interval = (int)Math.Ceiling(ts.TotalSeconds) * 1000;
        
    }

    /// <summary>
    /// 任务列表
    /// </summary>
    public async void Tasks(Object sou,ElapsedEventArgs s)
    {
        var url = await "http://localhost:5172/v1/api/Sentence/sentences".GetStringAsync();
        TestTimer.Interval = 10000;
        Console.WriteLine(s.SignalTime);
        Console.WriteLine(url);
    }

    // public static void main()
    // {
    //     Timer timer = new Timer(100);
    //     timer.AutoReset =  Auto;
    //     timer.Elapsed   += Tasks;
    // }
}