using learngate_api.Models;

namespace learngate_api.DTOs.ExamDto
{
    public class UpdateExamDto
    {
      
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LessonID { get; set; }
        
    }
}
