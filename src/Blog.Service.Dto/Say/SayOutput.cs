namespace Blog.Service.Dto.Say;

public class SayOutput
{
    public string   Title   { get; set; } = string.Empty;
    public string   Content { get; set; } = string.Empty;
    public DateTime CreateTime;
    public long     VisitCount { get; set; }
    
}