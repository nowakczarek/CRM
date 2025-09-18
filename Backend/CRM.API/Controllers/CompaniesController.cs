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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userIdClaim);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
        {
            var userId = GetUserId();

            var companies = await companyService.GetAllAsync(userId);
            return Ok(companies.Select(c => c.ToDto()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompanyDto>> GetById(Guid id)
        {
            var userId = GetUserId();
            var company = await companyService.GetByIdAsync(id, userId);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Add([FromBody] CreateCompanyDto dto)
        {
            var userId = GetUserId();
            
            var entity = dto.ToEntity(userId);
            var created = await companyService.AddAsync(entity, userId);

            return CreatedAtAction(
                nameof(GetById),
                new {id = created.Id},
                created.ToDto());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CompanyDto>> Update(Guid id, [FromBody] UpdateCompanyDto dto)
        {
            var userId = GetUserId();
            var company = await companyService.GetByIdAsync(id, userId);

            if (company == null)
            {
                return NotFound();
            }

            company.UpdateFrom(dto);

            var updated = await companyService.UpdateAsync(company, userId);

            return Ok(updated.ToDto());
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CompanyDto>> Delete(Guid id)
        {
            var userId = GetUserId();
            var successs = await companyService.DeleteAsync(id, userId);

            if (!successs)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
