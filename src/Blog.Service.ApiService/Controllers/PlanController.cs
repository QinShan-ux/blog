using Blog.Service.Common.Model;
using Blog.Service.Core.Plan;
using Blog.Service.Model.Dto.Plan;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Service.ApiService.Controllers;

/// <summary>
/// 博客
/// </summary>
[ApiController]
[Route("v1/api/[controller]")]
public class PlanController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    public readonly IPlanService PlanService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="planService"></param>
    public PlanController(IPlanService planService)
    {
        PlanService = planService;
    }

    /// <summary>
    /// 获取计划详情
    /// </summary>
    /// <returns>
    /// </returns>
    [HttpGet("plan/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(Result<PlanInfoDto>))]
    public async Task<IActionResult> GetPlanInfo(long id)
    {
        var res = await PlanService.GetPlanInfoAsync(id);
        // var res = new GetPlanInfoDto();
        return Ok(Result<PlanInfoDto>.Success(res));
    }

    
    
}