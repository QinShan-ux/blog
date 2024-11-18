namespace Blog.Service.Common.DBContect;

public class SqlOptions
{
    /// <summary>
    /// 使用选项模式绑定分层配置数据
    /// sql 连接串
    /// </summary>
    public const string SqlConnect = "SqlConnect";
    /// <summary>
    /// mysql 连接串
    /// </summary>
    public string MySql { get; set; } = String.Empty;
    
    /// <summary>
    /// SqlServer 连接串
    /// </summary>
    public string SqlServer { get; set; } = String.Empty;
    
    /// <summary>
    /// Oracle 连接串
    /// </summary>
    public string Oracle { get; set; } = String.Empty;
    
    /// <summary>
    /// PgSql 连接串
    /// </summary>
    public string PgSql { get; set; } = String.Empty;
}