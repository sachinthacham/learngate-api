using learngate_api.Models;
using System.ComponentModel.DataAnnotations;

namespace learngate_api.DTOs
{
    public class TeacherRegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

       
        public string[] Roles { get; set; } = new string[0];
       
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Email { get; set; }

        public string? Phone { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Img { get; set; }
        public string BloodType { get; set; } = string.Empty;

        public List<int> SubjectIds { get; set; } = new List<int>();
        public UserSex Sex { get; set; }

        public int ParentId { get; set; }


        public int ClassId { get; set; }


        public int GradeId { get; set; }
    }
}
