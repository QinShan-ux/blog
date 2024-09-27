namespace Blog.Service.Model.Dto.Memory;

public class MemoryInput
{
    /// <summary>
    /// id
    /// </summary>
    public long   Id    { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;
}