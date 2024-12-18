using learngate_api.Models;

namespace learngate_api.DTOs.StudentDto
{
    public class UpdateStudentDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }
        public string Address { get; set; }
        public string? Img { get; set; }
        public string BloodType { get; set; }


        public UserSex Sex { get; set; }

        public int ParentId { get; set; }


        public int ClassId { get; set; }


        public int GradeId { get; set; }
    }
}
