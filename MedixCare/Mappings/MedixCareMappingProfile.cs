using AutoMapper;
using MedixCare.DTOs;
using MedixCare.Models;
using MedixCare.ViewModels;

namespace MedixCare.Mappings
{
    public class MedixCareMappingProfile : Profile
    {
        public MedixCareMappingProfile() {

            //appointment Mappings
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();


            //Doctor Mappings
            CreateMap<Doctor, DoctorDTO>().ReverseMap();

            //Patients Mappings
            CreateMap<Patient, PatientDTO>().ReverseMap();

            //Department Mappings
            CreateMap<Department, DepartmentDTO>().ReverseMap();

            //Invoice Mappings
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();

            //UploadFIle Mappings
            CreateMap<UploadedFile, UploadedFileDTO>().ReverseMap();

            //CRMContact Mappings
            CreateMap<CRMContact, CRMContactDTO>().ReverseMap();

            //Notificatios Mappings
            CreateMap<Notification, NotificationDTO>().ReverseMap();


            //For Department Crud
            // Department -> DepartmentViewModel
            CreateMap<Department, DepartmentViewModel>().ForMember(dest => dest.ImageFile, opt => opt.Ignore());

            //// DepartmentViewModel -> Department
            CreateMap<DepartmentViewModel, Department>().ForMember(dest => dest.Image, opt => opt.Ignore());

        }

    }
}
