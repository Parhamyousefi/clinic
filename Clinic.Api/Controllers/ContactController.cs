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
        private readonly IContactsService _contactsService;

        public ContactController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpPost("saveContacts")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveContacts(SaveContactsDto model)
        {
            var result = await _contactsService.SaveContacts(model);
            return Ok(result);
        }

        [HttpGet("getContacts")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetContacts()
        {
            var result = await _contactsService.GetContacts();
            return Ok(result);
        }

        [HttpGet("deleteContacts/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteContacts(int id)
        {
            var result = await _contactsService.DeleteContacts(id);
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
