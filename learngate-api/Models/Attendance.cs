namespace learngate_api.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }  
        public bool Present { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
