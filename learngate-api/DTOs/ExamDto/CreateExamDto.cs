using learngate_api.Models;

namespace learngate_api.DTOs.ExamDto
{
    public class CreateExamDto
    {
       
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LessonID { get; set; }
        
      
    }
}
