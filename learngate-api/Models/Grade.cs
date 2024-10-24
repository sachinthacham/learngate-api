namespace learngate_api.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Level { get; set; }

        public List<Student> students { get; set; } = new List<Student>();
        public List<Class> classes { get; set; } = new List<Class>();
    }
}
