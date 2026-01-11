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
    public class LeadsController : ControllerBase
    {
        private readonly ILeadService leadService;

        public LeadsController(ILeadService leadService)
        {
            this.leadService = leadService;
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userIdClaim);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadDto>>> GetAll()
        {
            var userId = GetUserId();

            var leads = await leadService.GetAllAsync(userId);
            return Ok(leads.Select(a => a.ToFullDto()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LeadDto>> GetById(Guid id)
        {
            var userId = GetUserId();

            var lead = await leadService.GetByIdAsync(id, userId);

            if (lead is null)
            {
                return NotFound();
            }

            return Ok(lead.ToDto());
        }

        [HttpGet("company/{companyId:guid}")]
        public async Task<ActionResult<IEnumerable<LeadDto>>> GetByCompanyId(Guid companyId)
        {
            var userId = GetUserId();

            var leads = await leadService.GetByCompanyId(userId, companyId);
            return(Ok(leads.Select(l => l.ToDto())));   
        }

        [HttpGet("contact/{contactId:guid}")]
        public async Task<ActionResult<IEnumerable<LeadDto>>> GetByContactId(Guid contactId)
        {
            var userId = GetUserId();

            var leads = await leadService.GetByContactId(userId, contactId);
            return (Ok(leads.Select(l => l.ToDto())));
        }

        [HttpPost]
        public async Task<ActionResult<LeadDto>> Add([FromBody] CreateLeadDto dto)
        {
            var userId = GetUserId();

            var entity = dto.ToEntity(userId);
            var created = await leadService.AddAsync(entity, userId);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created.ToDto());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LeadDto>> Update(Guid id, [FromBody] UpdateLeadDto dto)
        {
            var userId = GetUserId();

            var lead = await leadService.GetByIdAsync(id, userId);

            if (lead is null)
            {
                return NotFound();
            }

            lead.UpdateFrom(dto);

            var updated = await leadService.UpdateAsync(lead, userId);

            return Ok(updated.ToDto());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = GetUserId();

            var success = await leadService.DeleteAsync(id, userId);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}   
