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
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userIdClaim);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactWithCompanyDto>>> GetAll()
        {
            var userId = GetUserId();

            var contacts = await contactService.GetAllAsync(userId);

            return Ok(contacts.Select(c => c.ToDtoWithCompany()));
        }

        [HttpGet("company/{companyId:guid}")]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetByCompanyId(Guid companyId)
        {
            var userId = GetUserId();

            var contacts = await contactService.GetByCompanyIdAsync(companyId, userId);

            return Ok(contacts.Select(c => c.ToDto()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactWithCompanyDto>> GetById(Guid id)
        {
            var userId = GetUserId();
            var contact = await contactService.GetByIdAsync(id, userId);

            if (contact is null)
            {
                return NotFound();
            }

            return Ok(contact.ToDtoWithCompany());
        }

        [HttpPost]
        public async Task<ActionResult<ContactDto>> Add([FromBody] CreateContactDto dto)
        {
            var userId = GetUserId();

            var entity = dto.ToEntity(userId);
            var created = await contactService.AddAsync(entity, userId);

            return CreatedAtAction(
                nameof(GetById),
                new {id = created.Id},
                created.ToDto());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ContactDto>> Update(Guid id, [FromBody] UpdateContactDto dto)
        {
            var userId = GetUserId();
            var contact = await contactService.GetByIdAsync(id, userId);

            if (contact is null)
            {
                return NotFound();
            }

            contact.UpdateFrom(dto);

            var updated = await contactService.UpdateAsync(contact, userId);

            return Ok(updated.ToDto());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = GetUserId();
            var success = await contactService.DeleteAsync(id, userId);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
