using learngate_api.DTOs.TeacherDto;
using learngate_api.Models;

namespace learngate_api.DTOs.SubjectDto
{
    public class GetSubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetTeacherNameDto> Teachers { get; set; } = new List<GetTeacherNameDto>();
       
    }
}
