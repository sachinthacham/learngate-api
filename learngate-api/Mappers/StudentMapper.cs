
using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.GradeDto;
using learngate_api.DTOs.ParentDto;
using learngate_api.DTOs.StudentDto;
using learngate_api.Models;
using System.Net;
using System.Numerics;

namespace learngate_api.Mappers
{
    public static class StudentMapper
    {
        public static GetStudentDto ToStudentDto(this Student studentModel)
        {
            return new GetStudentDto
            {
                Id= studentModel.Id,
                UserName = studentModel.UserName,
                Name = studentModel.Name,
                Surname = studentModel.Surname, 
                Email = studentModel.Email,
                Phone = studentModel.Phone,
                Address = studentModel.Address,
                Img = studentModel.Img,
                BloodType = studentModel.BloodType,
                Sex = studentModel.Sex,
                Parent = new GetParentNameDto
                {
                    Id = studentModel.Parent.Id,
                    Name = studentModel.Parent.Name,
                    Surname = studentModel.Parent.Surname
                },
                Class = new GetClassNameDto
                {
                    Id = studentModel.Class.Id,
                    Name= studentModel.Class.Name,
                },
                Grade = new GetGradeDto
                {
                    Id = studentModel.Grade.Id,
                    Level = studentModel.Grade.Level,
                }
               

            };

        }

        public static Student ToStudentModel(this CreateStudentDto studentDto)
        {
            return new Student
            {
                UserName = studentDto.UserName,
                Name = studentDto.Name,
                Surname = studentDto.Surname,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                Address = studentDto.Address,
                Img = studentDto.Img,
                BloodType = studentDto.BloodType,
                GradeId = studentDto.GradeId,
                Sex = studentDto.Sex,
                ParentId = studentDto.ParentId,
                ClassId = studentDto.ClassId,

            };
        }
    }
}









