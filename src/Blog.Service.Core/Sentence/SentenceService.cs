using Blog.Service.Common.DBContect;
using Blog.Service.Model.Dto.Sentence;
using Blog.Service.Model.Entities;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace Blog.Service.Core.Sentence;

public class SentenceService(DbContext context,IMapper mapper,ILogger<SentenceService> logger) : ISentenceService
{
    public async Task<SentenceDto> GetSentenceAsync(long id)
    {
        using var ctx      = context.CreateConnect();
        var       entities = await ctx.Queryable<SentenceEntity>().Where(it => it.Id == id).FirstAsync();
        return mapper.Map<SentenceDto>(entities);
    }
    
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertAsync(SentenceEntity entity)
    {
        using var ctx = context.CreateConnect();
        try
        {
            await ctx.Insertable(entity)
                .InsertColumns(it => new
                {
                    it.Content
                })
                .ExecuteCommandAsync();
        }
        catch (Exception e)
        {
            logger.LogInformation("插入失败");
            Console.WriteLine(e.Data);
            throw ;
        }
        
    }

    public async Task<List<SentenceDto>> GetSentencesAsync()
    {
        using var ctx = context.CreateConnect();
        var       res = await ctx.Queryable<SentenceEntity>()
            .Select<SentenceDto>()
            .ToListAsync();
        return res;
    }

    
}