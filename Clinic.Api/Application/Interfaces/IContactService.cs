using Clinic.Api.Application.DTOs.Contacts;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IContactService
    {
        Task<string> SaveContact(SaveContactDto model);
        Task<IEnumerable<ContactsContext>> GetContacts();
        Task<string> DeleteContact(int id);
        Task<IEnumerable<ContactTypesContext>> GetContactTypes();
    }
}
