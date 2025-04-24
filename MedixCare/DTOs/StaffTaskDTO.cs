namespace MedixCare.DTOs
{
    public class StaffTaskDTO
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
