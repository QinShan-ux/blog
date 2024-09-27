using SqlSugar;

namespace Blog.Service.Model.Entities;
/// <summary>
/// 每日一句
/// </summary>
public class SentenceEntity
{
    /// <summary>
    /// id
    /// </summary>
    [SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
    public long   Id      { get; set; }
    
    /// <summary>
    /// 内容
    /// </summary>
    [SugarColumn(ColumnDataType = "text")]
    public string Content { get; set; }

    /// <summary>
    /// 访客id
    /// </summary>
    public long UId { get; set; } = 0;
    /// <summary>
    /// 赞同
    /// </summary>
    [SugarColumn(ColumnDataType = "bigint",DefaultValue = "0")]
    public long Up { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [SugarColumn(ColumnDataType = "timestamp", DefaultValue = "now()")]   
    public DateTime CreateTime { get; set; }


}