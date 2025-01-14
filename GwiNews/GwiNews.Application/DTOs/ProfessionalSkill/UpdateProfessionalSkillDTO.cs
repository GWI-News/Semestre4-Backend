namespace GwiNews.Application.DTOs.ProfessionalSkill
{
    public class UpdateProfessionalSkillDTO
    {
        public Guid? Id { get; set; }
        public string? Skill1 { get; set; }
        public string? Skill2 { get; set; }
        public string? Skill3 { get; set; }
        public string? Skill4 { get; set; }
        public bool? Status { get; set; }
        public Guid? UserId { get; set; }
    }
}
