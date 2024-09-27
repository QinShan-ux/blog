using SqlSugar;

namespace Blog.Service.Model.Entities;


public class PlanEntity
{
    [SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
    public long         Id              { get; set; }
    [SugarColumn(ColumnDataType = "text")]
    public string       Plan            { get;      set; } = string.Empty;
    [SugarColumn(IsJson = true)]
    public List<Inspiration> Inspirations { get; set; } = new List<Inspiration>();
    [SugarColumn(IsJson = true)]
    public List<Trouble>      Troubles        { get; set; } = new List<Trouble>();

    public string   SuccessTag  { get; set; } = string.Empty;
    [SugarColumn(ColumnDataType = "timestamp", DefaultValue = "now()")]
    public DateTime CreateTime  { get; set; }
    [SugarColumn(ColumnDataType = "timestamp", DefaultValue = "now()")]
    public DateTime SuccessTime { get; set; }
    [SugarColumn(ColumnDataType = "bigint", DefaultValue = "0")]
    public long     VisitCount { get; set; }
}

public class Inspiration
{
    public string   Content    { get; set; } = string.Empty;
    public DateTime CreateTime { get; set; }
}

public class Trouble
{
    public string Content { get; set; } = string.Empty;
    
    public DateTime CreateTime { get; set; }
}