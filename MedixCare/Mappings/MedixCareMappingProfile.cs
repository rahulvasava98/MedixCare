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
            CreateMap<Appointment, DTOs.AppointmentDTO>().ReverseMap();


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


        }

    }
}
