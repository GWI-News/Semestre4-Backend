namespace GwiNews.Application.DTOs.FormationDTO
{
    public class UpdateFormationDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Institution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Activity1 { get; set; }
        public string? Activity2 { get; set; }
        public string? Activity3 { get; set; }
        public bool? Status { get; set; }
        public Guid? UserId { get; set; }
    }
}
