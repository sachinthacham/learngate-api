namespace learngate_api.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int capacity { get; set; }
        public int SupervisorId { get; set; }
        public Teacher Supervisor { get; set; } 
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
