using learngate_api.DTOs.SubjectDto;
using learngate_api.Models;


namespace learngate_api.Mappers
{
    public static class SubjectMapper
    {
        public static GetSubjectDto ToSubjectDto(this Subject SubjectModel)
        {
            return new GetSubjectDto
            {
                Id = SubjectModel.Id,
                Name = SubjectModel.Name,
                
            };
        }

        public static Subject ToSubjectModel(this CreateSubjectDto SubjectDto)
        {
            return new Subject
            {
               
                Name = SubjectDto.Name,
               
            };
        }
    }
}
