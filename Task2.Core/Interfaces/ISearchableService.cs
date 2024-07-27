using Task2.Core.Models;

namespace Task2.Core.Interfaces;

public interface ISearchableService
{
    Task<SearchResponse> GetMatchedResultAsync(SearchRequest request);
}
