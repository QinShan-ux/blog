using Blog.Service.Common.DBContect;
using Blog.Service.Model.Dto.Memory;
using Blog.Service.Model.Entities;
using MapsterMapper;

namespace Blog.Service.Core.Memory;

public class MemoryService : IMemoryService
{
    public readonly  DbContext _context;
    private readonly IMapper   _mapper;

    public MemoryService(DbContext context,IMapper mapper)
    {
        _context = context;
        _mapper  = mapper;
    }
    
    public async Task<MemoryInfoDto> GetMemoryInfoAsync(MemoryInput input)
    {
        using var ctx      = _context.CreateConnect();
        var       entities = await ctx.Queryable<MemoryEntity>().Where(it => it.Id == input.Id).FirstAsync();
        var       res      = _mapper.Map<MemoryInfoDto>(entities);
        return res;
    }
}