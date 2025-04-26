using System.ComponentModel.DataAnnotations;

namespace MedixCare.Models
{
    public class UploadedFile
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public string FileType { get; set; }

    }
}
