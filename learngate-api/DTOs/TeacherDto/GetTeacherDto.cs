using learngate_api.DTOs.SubjectDto;
using learngate_api.Models;

namespace learngate_api.DTOs.TeacherDto
{
    public class GetTeacherDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Email { get; set; }

        public string? Phone { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Img { get; set; }
        public string BloodType { get; set; } = string.Empty;
        public List<GetSubjectNameDto> Subjects { get; set; } = new List<GetSubjectNameDto>();

       
        public UserSex Sex { get; set; }
      

    }
}
