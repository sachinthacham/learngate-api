namespace learngate_api.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

       
    }
}
