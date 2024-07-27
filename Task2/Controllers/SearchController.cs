using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Interfaces;
using Task2.Core.Models;

namespace Task2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchableService _searchableService;
    public SearchController(ISearchableService searchableService)
    {
        _searchableService = searchableService;
    }

    [HttpPost("Result")]
    [ProducesResponseType(typeof(SearchResponse), 200)]
    public async Task<IActionResult> GetMatchAsync([FromBody] SearchRequest request)
    {
        var response = await _searchableService.GetMatchedResultAsync(request);
        return Ok(response);
    }
}
