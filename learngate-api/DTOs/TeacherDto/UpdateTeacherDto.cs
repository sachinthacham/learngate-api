using learngate_api.Models;

namespace learngate_api.DTOs.TeacherDto
{
    public class UpdateTeacherDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Email { get; set; }

        public string? Phone { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Img { get; set; }
        public string BloodType { get; set; } = string.Empty;


        public UserSex Sex { get; set; }
    }
}
