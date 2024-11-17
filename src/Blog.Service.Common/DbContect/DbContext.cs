using Blog.Service.Model.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace Blog.Service.Common.DBContect;

public class DbContext(IConfiguration configuration,ILogger<DbContext> _logger)
{
    private readonly string _sqlConnect = configuration.GetSection("ConnectStr:SqlConfigs")["PgSql"] ?? "";
    private readonly bool   _isCordFirst = (configuration.GetSection("ConnectStr")["IsCodeFirst"] ?? "").ToLowerInvariant().Equals("true") ;
    public SqlSugarClient CreateConnect()
    {
        
        using var client = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = _sqlConnect,
            DbType = DbType.PostgreSQL,
            IsAutoCloseConnection = true,
            InitKeyType = InitKeyType.Attribute,
            ConfigureExternalServices = new ConfigureExternalServices()
            {
                EntityService = (x, p) =>
                {
                    p.DbColumnName = UtilMethods.ToUnderLine(p.DbColumnName);
                },
                EntityNameService = (x, p) =>
                {
                    p.DbTableName = UtilMethods.ToUnderLine(p.DbTableName.Replace("Entity", ""));
                }
            }
        });
        // 没有数据库时，建库
        client.Context.DbMaintenance.CreateDatabase();
        // 哪些实体需要在数据库里创建
        client.Context.CodeFirst.SetStringDefaultLength(50).InitTables(new[]
        {
        typeof(PlanEntity),
        typeof(MemoryEntity),
        typeof(SentenceEntity) 
        });

         client.Aop.OnLogExecuting = (sql, pars) =>
         {
             Console.WriteLine("SQL ==> " + sql);
             foreach (var par in pars)
             {
                 Console.WriteLine(par.Value);
             }
         };
         client.Aop.OnLogExecuted = (sql, result) =>
         {
             Console.WriteLine("结果集合输出");
             foreach (var item in result)
             {
                 Console.WriteLine(item.ToString());
             }
         };
         
        return client;
    }
    
}