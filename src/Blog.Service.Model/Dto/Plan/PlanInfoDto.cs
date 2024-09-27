using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Service.Model.Dto.Plan;
/// <summary>
/// 获取计划详情
/// </summary>
public class PlanInfoDto
{
    /// <summary>
    /// 计划
    /// </summary>
    [Description("问题")]
    public string Plan { get; set; } = string.Empty;
    /// <summary>
    /// 灵感
    /// </summary>
    [Description("问题")]
    public List<string> InspirationList { get; set; } = new List<string>();
    /// <summary>
    /// 问题
    /// </summary>
    [Description("问题")]
    public List<string> Trouble         { get; set; } = new List<string>();

    /// <summary>
    /// 完成
    /// </summary>
    public string SuccessTag { get; set; } = string.Empty;
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime     CreateTime      { get; set; }
    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime     SuccessTime     { get; set; }
}