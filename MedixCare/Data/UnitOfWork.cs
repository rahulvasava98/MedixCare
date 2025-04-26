using MedixCare.Models;

namespace MedixCare.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Appointment> Appointments { get; private set; }
        public IRepository<Doctor> Doctors { get; private set; }
        public IRepository<Patient> Patients { get; private set; }
        public IRepository<Department> Departments { get; private set; }
        public IRepository<CRMContact>  CRMContacts { get; private set; }
        public IRepository<Invoice> Invoices { get; private set; }
        public IRepository<Notification> Notifications { get; private set; }
        public IRepository<UploadedFile> UploadedFiles { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Appointments = new Repository<Appointment>(_context);
            Doctors = new Repository<Doctor>(_context);
            Patients = new Repository<Patient>(_context);
            Departments = new Repository<Department>(_context);
            CRMContacts = new Repository<CRMContact>(_context);
            Invoices = new Repository<Invoice>(_context);
            UploadedFiles = new Repository<UploadedFile>(_context);
            Notifications = new Repository<Notification>(_context);



        }

        //public void Dispose() => _context.Dispose();
        public void Dispose()
        {
            _context.Dispose();
        }


        //public async Task SaveAsync() => await _context.SaveChangesAsync();
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
