using Blog.Service.Common.Model;
using Blog.Service.Core.Memory;
using Blog.Service.Model.Dto.Memory;
using Microsoft.AspNetCore.Mvc;
namespace Blog.Service.ApiService.Controllers;

/// <summary>
/// 日常
/// </summary>
[ApiController]
[Route("v1/api/[controller]")]
public class MemoryController : ControllerBase
{
    private readonly IMemoryService _memoryService;
    
    public MemoryController(IMemoryService memoryService)
    {
        _memoryService = memoryService;
    }

    /// <summary>
    /// 获取日常
    /// </summary>
    /// <returns></returns>
    [HttpPost("GetSayInfo")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(Result<MemoryInfoDto>))]
    public async Task<IActionResult> GetSayInfo([FromBody]MemoryInput input)
    {
        var res = await _memoryService.GetMemoryInfoAsync(input);
        return Ok(Result<MemoryInfoDto>.Success(res));
    }
}