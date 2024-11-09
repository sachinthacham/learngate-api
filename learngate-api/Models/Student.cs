namespace learngate_api.Models
{
    public enum UserSex
    {
        Male,
        Female
    }
    public class Student
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set;}

        public string? Phone { get; set; }
        public string Address { get; set; }
        public string? Img {  get; set; }
        public string BloodType { get; set; }

        public DateTime CreatedAt { get; set; }
        public UserSex Sex { get; set;}

        public int ParentId { get; set; }
        public Parent Parent { get; set; }
     
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        public List<Result> Results { get; set; } = new List<Result>();
        //public List<Assignment> Assignment { get; set; }
    
    }
}
