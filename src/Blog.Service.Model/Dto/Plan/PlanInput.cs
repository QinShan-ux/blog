namespace Blog.Service.Model.Dto.Plan;

public class PlanInput
{
    /// <summary>
    /// id
    /// </summary>
    public long   Id   { get; set; }
    
    /// <summary>
    /// 计划
    /// </summary>
    public string Plan { get; set; } = string.Empty;
}