using Clinic.Api.Application.DTOs.Contacts;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IContactsService
    {
        Task<string> SaveContacts(SaveContactsDto model);
        Task<IEnumerable<ContactsContext>> GetContacts();
        Task<string> DeleteContacts(int id);
        Task<IEnumerable<ContactTypesContext>> GetContactTypes();
    }
}
