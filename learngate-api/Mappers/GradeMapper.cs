using learngate_api.DTOs.GradeDto;
using learngate_api.Models;

namespace learngate_api.Mappers
{
    public static class GradeMapper
    {
        public static GetGradeDto ToGradeDto(this Grade gradeModel)
        {
            return new GetGradeDto
            {
                Id = gradeModel.Id,
                Level = gradeModel.Level,
            };
        } 

        public static Grade ToGradeModel(this CreateGradeDto gradeDto) 
        {
            return new Grade
            {
                Level = gradeDto.Level,
            };
        
        }
    }
}
