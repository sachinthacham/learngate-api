using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.LessonDto;
using learngate_api.DTOs.SubjectDto;
using learngate_api.Models;

namespace learngate_api.DTOs.ExamDto
{
    public class GetExamDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SubjectId { get; set; }
        public GetSubjectNameDto Subject { get; set; }
        public int LessonID { get; set; }
        public GetLessonNameDto Lesson { get; set; }
        public GetClassNameDto Class { get; set; }
    }
}
