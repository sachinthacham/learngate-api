namespace learngate_api.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int LessonID { get; set; }
        public Lesson Lesson { get; set; }
        public List<Result> Results { get; set; } = new List<Result>();
    }
}
