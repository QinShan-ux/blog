using Blog.Service.Common.DBContect;
using Blog.Service.Model.Dto.Plan;
using Blog.Service.Model.Entities;
using MapsterMapper;


namespace Blog.Service.Core.Plan;

public class PlanService : IPlanService
{
    public readonly  DbContext _context;
    private readonly IMapper   _mapper;

    public PlanService(DbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<PlanInfoDto> GetPlanInfoAsync(long id)
    {
        using var ctx = _context.CreateConnect();
        
        var entities = await ctx.Queryable<PlanEntity>().Where(it => it.Id == id).FirstAsync();
        var res = _mapper.Map<PlanInfoDto>(entities);
        return res;
    }

    public Task<PlanInfoDto> GetPlanListAsync()
    {
        throw new NotImplementedException();
    }
}