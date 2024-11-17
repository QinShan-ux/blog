using Blog.Service.Model.Dto.Sentence;
using Blog.Service.Model.Entities;

namespace Blog.Service.Core.Sentence;

public interface ISentenceService
{
    Task<SentenceDto> GetSentenceAsync(long id);

    Task InsertAsync(SentenceEntity entity);

    Task<List<SentenceDto>> GetSentencesAsync();
    
}