namespace learngate_api.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }
        public string Address { get; set; }
        public string? Img { get; set; }
        public string BloodType { get; set; }

        public DateTime CreatedAt { get; set; }
        public UserSex Sex { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List <Lesson> Lessons { get; set; }= new List<Lesson>();

        public List<Class> Classs { get; set; } = new List<Class>();

    }
}
