namespace Blog.Service.Model.Dto.Memory;

public class MemoryInfoDto
{
    /// <summary>
    /// 主题
    /// </summary>
    public string   Title   { get; set; } = string.Empty;
    
    /// <summary>
    /// 内容
    /// </summary>
    public string   Content { get; set; } = string.Empty;
    
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime;
    /// <summary>
    /// 访问次数
    /// </summary>
    public long     VisitCount { get; set; }
    
}