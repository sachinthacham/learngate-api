
using learngate_api.DTOs.TeacherDto;
using learngate_api.Models;
using System.Net;
using System.Numerics;


namespace learngate_api.Mappers
{
    public static class TeacherMapper
    {
       public static GetTeacherDto ToTeacherDto(this Teacher teacherModel)
        {
            return new GetTeacherDto
            {
                Id = teacherModel.Id,
                UserName = teacherModel.UserName,
                Name = teacherModel.Name,
                Surname = teacherModel.Surname,
                Email = teacherModel.Email,
                Phone = teacherModel.Phone,
                Address = teacherModel.Address,   
                Img = teacherModel.Img,
                BloodType = teacherModel.BloodType,
                Sex = teacherModel.Sex,
                Teacher
            };
        }

        public static Teacher ToTeacherModel(this CreateTeacherDto teacherDto)
        {
            return new Teacher
            {
              
                UserName = teacherDto.UserName,
                Name = teacherDto.Name,
                Surname = teacherDto.Surname,
                Email = teacherDto.Email,
                Phone = teacherDto.Phone,
                Address = teacherDto.Address,
                Img = teacherDto.Img,
                BloodType = teacherDto.BloodType,
                Sex = teacherDto.Sex
            };
        }

    }
}

                