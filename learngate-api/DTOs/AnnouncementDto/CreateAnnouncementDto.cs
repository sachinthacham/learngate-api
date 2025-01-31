namespace learngate_api.DTOs.AnnouncementDto
{
    public class CreateAnnouncementDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ClassId { get; set; }
    }
}
