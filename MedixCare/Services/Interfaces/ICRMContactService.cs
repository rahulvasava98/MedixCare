using MedixCare.ViewModels;

namespace MedixCare.Services.Interfaces
{
    public interface ICRMContactService
    {
        Task<IEnumerable<CRMContactDTO>> GetAllContactsAsync();
        Task<CRMContactDTO> GetContactByIdAsync(int id);
        Task AddContactAsync(CRMContactDTO contactDto);
        Task DeleteContactAsync(int id);
    }
}
