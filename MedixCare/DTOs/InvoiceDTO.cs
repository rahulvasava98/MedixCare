namespace MedixCare.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; } = string.Empty;

    }
}
