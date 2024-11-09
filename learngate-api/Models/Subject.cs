namespace learngate_api.Models
{
   
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();


        //subject and teacher join table
        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    }
}
