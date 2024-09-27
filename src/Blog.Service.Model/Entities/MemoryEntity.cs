using SqlSugar;

namespace Blog.Service.Model.Entities;
/// <summary>
/// 生活日常 （回忆）
/// </summary>
public class MemoryEntity
{
    [SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
    public long Id { get; set; }
    public string Title   { get; set; } = string.Empty;
    [SugarColumn(ColumnDataType = "text")]
    public string Content { get; set; } = string.Empty;
    [SugarColumn(ColumnDataType = "timestamp", DefaultValue = "now()")]
    public DateTime CreateTime { get; set; }
    [SugarColumn(ColumnDataType = "bigint", DefaultValue = "0")]
    public long     VisitCount { get; set; }
}