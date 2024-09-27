using Blog.Service.Model.Dto.Memory;


namespace Blog.Service.Core.Memory;

public interface IMemoryService
{
    public Task<MemoryInfoDto> GetMemoryInfoAsync(MemoryInput input);
}