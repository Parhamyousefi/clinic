using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Contacts;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;
        private readonly IReadTokenClaims _token;
        private readonly IMapper _mapper;

        public ContactService(ApplicationDbContext context, IReadTokenClaims token, IMapper mapper)
        {
            _context = context;
            _token = token;
            _mapper = mapper;
        }

        public async Task<GlobalResponse> SaveContact(SaveContactDto model)
        {
            var userId = _token.GetUserId();
            var result = new GlobalResponse();

            try
            {
                if (model.EditOrNew == -1)
                {
                    var contact = _mapper.Map<ContactsContext>(model);
                    contact.CreatorId = userId;
                    contact.CreatedOn = DateTime.UtcNow;
                    _context.Contacts.Add(contact);
                    await _context.SaveChangesAsync();
                    result.Data = "Contact Saved Successfully";
                    return result;
                }
                else
                {
                    var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == model.EditOrNew);
                    if (existingContact == null)
                        throw new Exception("Contact Not Found");

                    _mapper.Map(model, existingContact);
                    existingContact.ModifierId = userId;
                    existingContact.LastUpdated = DateTime.UtcNow;
                    _context.Contacts.Update(existingContact);
                    await _context.SaveChangesAsync();
                    result.Data = "Contact Updated Successfully";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ContactsContext>> GetContacts()
        {
            try
            {
                var contacts = await _context.Contacts.ToListAsync();
                return contacts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteContact(int id)
        {
            var result = new GlobalResponse();
            try
            {
                var contact = await _context.Contacts.FindAsync(id);
                if (contact == null) throw new Exception("Contact Not Found");

                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                result.Data = "Contact Deleted Successfully";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ContactTypesContext>> GetContactTypes()
        {
            try
            {
                var contactTypes = await _context.ContactTypes.ToListAsync();
                return contactTypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
