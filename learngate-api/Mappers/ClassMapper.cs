using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.GradeDto;
using learngate_api.DTOs.TeacherDto;
using learngate_api.Models;
using System.Runtime.CompilerServices;

namespace learngate_api.Mappers
{
    public static class ClassMapper
    {
        public static GetClassDto ToClassDto(this Class classModel)
        {
            return new GetClassDto
            {
                Id = classModel.Id,
                Name = classModel.Name,
                Capacity = classModel.Capacity,
                SupervisorId = classModel.SupervisorId,
                GradeId = classModel.GradeId,
                Grade = new GetGradeDto
                {
                    Id = classModel.Grade.Id,
                    Level = classModel.Grade.Level
                },
                Supervisor = new GetTeacherNameDto
                {
                    Id = classModel.Supervisor.Id,
                    Name = classModel.Supervisor.Name,
                    Surname = classModel.Supervisor.Surname
                }
            };
        }

        public static Class ToClassModel(this CreateClassDto classDto)
        {
            return new Class
            {
                Name = classDto.Name,
                Capacity = classDto.Capacity,
                SupervisorId = classDto.SupervisorId,
                GradeId = classDto.GradeId,
            };   
        }
    }
}
