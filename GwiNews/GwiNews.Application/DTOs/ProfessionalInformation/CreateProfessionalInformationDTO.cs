namespace GwiNews.Application.DTOs.ProfessionalInformation
{
    public class CreateProfessionalInformationDTO
    {
        public string? CompleteName { get; set; }
        public string? Email { get; set; }
        public string? CompleteAddress { get; set; }
        public string? Objective { get; set; }
        public string? ImgUrl { get; set; }
        public bool? Status { get; set; }
        public string? WorkPlatformUrl { get; set; }
        public Guid? UserId { get; set; }
    }
}
