using MedixCare.Models;
using System.Numerics;

namespace MedixCare.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Appointment> Appointments { get; }
        IRepository<Doctor> Doctors { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Department> Departments { get; }
        IRepository<CRMContact> CRMContacts { get; }         
        IRepository<Invoice> Invoices { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<UploadedFile> UploadedFiles { get; }
        
        
        Task SaveAsync();


    }
}
