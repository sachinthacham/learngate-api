using learngate_api.DTOs.ParentDto;
using learngate_api.DTOs.StudentDto;
using learngate_api.Models;

namespace learngate_api.Mappers
{
    public static class ParentMapper
    {
        public static GetParentDto ToParentDto(this Parent parentModel)
        {
            return new GetParentDto
            {
                Id = parentModel.Id,
                UserName = parentModel.UserName,
                Name = parentModel.Name,
                Surname = parentModel.Surname,
                Email = parentModel.Email,
                Phone = parentModel.Phone,
                Address = parentModel.Address,
                Students = parentModel.Students.Select(x => new GetStudentNameDto
                {
                      Id = x.Id,
                      Name = x.Name,
                      Surname = x.Surname,
                }).ToList()

            };
        }

        public static Parent ToParentModel(this CreateParentDto parentDto)
        {
            return new Parent
            {
               
                UserName = parentDto.UserName,
                Name = parentDto.Name,
                Surname = parentDto.Surname,
                Email = parentDto.Email,
                Phone = parentDto.Phone,
                Address = parentDto.Address,
            };
        }
    }
}
