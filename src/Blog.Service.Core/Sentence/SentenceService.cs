using System.Linq.Expressions;
using Blog.Service.Common.DBContect;
using Blog.Service.Model.Dto.Sentence;
using Blog.Service.Model.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Service.Core.Sentence;

public class SentenceService : ISentenceService
{
    public readonly  DbContext _context;
    private readonly IMapper   _mapper;

    public SentenceService(DbContext context,IMapper mapper)
    {
        _context = context;
        _mapper  = mapper;
    }
    public async Task<SentenceDto> GetSentenceAsync(long id)
    {
        using var ctx      = _context.CreateConnect();
        var       entities = await ctx.Queryable<SentenceEntity>().Where(it => it.Id == id).FirstAsync();
        return _mapper.Map<SentenceDto>(entities);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertAsync(SentenceEntity entity)
    {
        using var ctx = _context.CreateConnect();
        try
        {
            await ctx.Insertable<SentenceEntity>(entity)
                .InsertColumns(it => new
                {
                    it.Content,
                    it.UId,
                    it.CreateTime
                })
                .ExecuteCommandAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw ;
        }
        
    }

    public async Task<List<SentenceDto>> GetSentencesAsync()
    {
        using var ctx = _context.CreateConnect();
        var       res = await ctx.Queryable<SentenceEntity>()
            .Select<SentenceDto>()
            .ToListAsync();
        return res;
    }
}