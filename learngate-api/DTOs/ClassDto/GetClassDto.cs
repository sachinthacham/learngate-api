using learngate_api.DTOs.GradeDto;
using learngate_api.DTOs.TeacherDto;
using learngate_api.Models;

namespace learngate_api.DTOs.ClassDto
{
    public class GetClassDto
    {
        public int Id { get; set; }
        public string Name { get; set;} = string.Empty;
        public int Capacity { get; set;}
        public int SupervisorId { get; set; }
        public int GradeId { get; set; }

        public GetGradeDto Grade { get; set; }
        public GetTeacherNameDto Supervisor { get; set; }
    }
}
