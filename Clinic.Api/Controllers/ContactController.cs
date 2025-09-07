using Clinic.Api.Application.DTOs.Contacts;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactsService;

        public ContactController(IContactService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpPost("saveContact")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveContact(SaveContactDto model)
        {
            var result = await _contactsService.SaveContact(model);
            return Ok(result);
        }

        [HttpGet("getContacts")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetContacts()
        {
            var result = await _contactsService.GetContacts();
            return Ok(result);
        }

        [HttpGet("deleteContact/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactsService.DeleteContact(id);
            return Ok(result);
        }

        [HttpGet("getContactTypes")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetContactTypes()
        {
            var result = await _contactsService.GetContactTypes();
            return Ok(result);
        }
    }
}
