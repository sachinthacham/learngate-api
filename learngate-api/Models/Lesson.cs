namespace learngate_api.Models
{
    public enum Day
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
    }
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Day Day { get; set; }
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set;}

        public int SubjectId {  get; set;}
        public Subject Subject { get; set;}
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Exam> Exams { get; set; }=new List<Exam>();
        //public List<Assignment> assignments { get; set; } = new List<Assignment>();

        public List<Attendance> Attendances { get; set; }


    }
}
