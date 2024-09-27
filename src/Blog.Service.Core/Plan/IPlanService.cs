

using Blog.Service.Model.Dto.Plan;

namespace Blog.Service.Core.Plan;

public interface IPlanService
{
   public Task<PlanInfoDto> GetPlanInfoAsync(long id);
   public Task<PlanInfoDto> GetPlanListAsync();
}