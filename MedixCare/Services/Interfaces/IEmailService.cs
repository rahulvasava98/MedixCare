namespace MedixCare.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(String toEmail, String subject, String messageBody);
    }
}
