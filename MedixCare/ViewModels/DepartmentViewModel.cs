using System.ComponentModel.DataAnnotations;

namespace MedixCare.ViewModels
{
    public class DepartmentViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100,ErrorMessage = "Department name cannot exceed 100 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = " Description cannot exceed 500 characters ")]
        public string Description { get; set; }

        // This will store the uploaded file (Profile photo)
        public IFormFile? ImageFile { get; set; }

        // This will store the image file name/path for display purposes
        public string? ExistingImagePath { get; set; }

    }
}
