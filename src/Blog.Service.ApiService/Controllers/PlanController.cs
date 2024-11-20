using Blog.Service.Common.Model;
using Blog.Service.Core.Plan;
using Blog.Service.Model.Dto.Plan;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Service.ApiService.Controllers;

/// <summary>
/// 计划
/// </summary>
[ApiController]
[Route("v1/api/[controller]")]
public class PlanController(IPlanService planService,ILogger<PlanController> logger) : ControllerBase
{
    
    /// <summary>
    /// 获取计划详情
    /// </summary>
    /// <returns>
    /// </returns>
    [HttpGet("plan/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(Result<PlanInfoDto>))]
    public async Task<IActionResult> GetPlanInfo(long id)
    {
        var res = await planService.GetPlanInfoAsync(id);
        return Ok(Result<PlanInfoDto>.Success(res));
    }

    
    
}