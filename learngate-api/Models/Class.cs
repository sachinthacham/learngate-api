namespace learngate_api.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int SupervisorId { get; set; }
        public int GradeId { get; set; }



        public Grade Grade { get; set; }
        public Teacher Supervisor { get; set; }

        
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Announcement> Announcements { get; set; } = new List<Announcement>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
