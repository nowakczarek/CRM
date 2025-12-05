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
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivitiesController(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userIdClaim);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FullActivityDto>>> GetAll()
        {
            var userId = GetUserId();

            var activities = await activityService.GetAllAsync(userId);
            return Ok(activities.Select(a => a.ToFullDto()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ActivityDto>> GetById(Guid id)
        {
            var userId = GetUserId();
            var activity = await activityService.GetByIdAsync(id, userId);

            if (activity is null)
            {
                return NotFound();
            }

            return Ok(activity.ToDto());
        }

        [HttpGet("contact/{contactId:guid}")]
        public async Task<ActionResult<IEnumerable<FullActivityDto>>> GetAllByContactId(Guid contactId)
        {
            var userId = GetUserId();

            var activities = await activityService.GetAllByContactId(contactId, userId);

            return Ok(activities.Select(a => a.ToFullDto()));

        }

        [HttpPost]
        public async Task<ActionResult<ActivityDto>> Add([FromBody]CreateActivityDto dto)
        {
            var userId = GetUserId();

            var entity = dto.ToEntity(userId);
            var created = await activityService.AddAsync(entity, userId);

            return CreatedAtAction(
                nameof(GetById),
                new {id = created.Id},
                created.ToDto());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ActivityDto>> Update(Guid id, [FromBody] UpdateActivityDto dto)
        {
            var userId = GetUserId();
            var activity = await activityService.GetByIdAsync(id, userId);

            if (activity is null)
            {
                return NotFound();
            }

            activity.UpdateFrom(dto);

            var updated = await activityService.UpdateAsync(activity, userId);

            return Ok(updated.ToDto());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = GetUserId();
            var success = await activityService.DeleteAsync(id, userId);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
