namespace learngate_api.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public DateTime StartTime {  get; set; }
        public DateTime EndTime { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int LessonID { get; set; }
        public Lesson Lesson { get; set; } 
        
        public List<Result> Results { get; set; }   = new List<Result>();





    }
}
