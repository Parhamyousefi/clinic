using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Contacts;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IContactService
    {
        Task<GlobalResponse> SaveContact(SaveContactDto model);
        Task<IEnumerable<ContactsContext>> GetContacts();
        Task<GlobalResponse> DeleteContact(int id);
        Task<IEnumerable<ContactTypesContext>> GetContactTypes();
        Task<GlobalResponse> SaveContactPhone(SaveContactPhoneDto model);
        Task<IEnumerable<ContactPhonesContext>> GetContactPhone(int contactId);
    }
}
