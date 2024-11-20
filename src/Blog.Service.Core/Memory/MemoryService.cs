using Blog.Service.Common.DBContect;
using Blog.Service.Model.Dto.Memory;
using Blog.Service.Model.Entities;
using MapsterMapper;

namespace Blog.Service.Core.Memory;

public class MemoryService(DbContext context,IMapper mapper) : IMemoryService
{
    public async Task<MemoryInfoDto> GetMemoryInfoAsync(MemoryInput input)
    {
        using var ctx      = context.CreateConnect();
        var       entities = await ctx.Queryable<MemoryEntity>().Where(it => it.Id == input.Id).FirstAsync();
        var       res      = mapper.Map<MemoryInfoDto>(entities);
        return res;
    }
}