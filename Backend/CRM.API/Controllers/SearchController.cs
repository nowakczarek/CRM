using System.Security.Claims;
using CRM.Application.DTOs;
using CRM.Application.Mappers;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userIdClaim);
        }

        [HttpGet("search={phrase}")]
        public async Task<ActionResult<IEnumerable<GlobalSearchDto>>> Search(string phrase)
        {
            var userId = GetUserId();

            var search = await searchService.GlobalSearch(phrase, userId);

            return Ok(search.ToGlobalSearchDto());
        }
    }
}
