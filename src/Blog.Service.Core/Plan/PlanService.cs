using Blog.Service.Common.DBContect;
using Blog.Service.Model.Dto.Plan;
using Blog.Service.Model.Entities;
using MapsterMapper;


namespace Blog.Service.Core.Plan;

public class PlanService(DbContext context,IMapper mapper) : IPlanService
{
    public async Task<PlanInfoDto> GetPlanInfoAsync(long id)
    {
        using var ctx = context.CreateConnect();
        
        var entities = await ctx.Queryable<PlanEntity>().Where(it => it.Id == id).FirstAsync();
        var res = mapper.Map<PlanInfoDto>(entities);
        return res;
    }

    public Task<List<PlanInfoDto>> GetPlanListAsync()
    {
        throw new NotImplementedException();
    }
}