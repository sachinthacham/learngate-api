using learngate_api.DTOs.SubjectDto;
using learngate_api.DTOs.TeacherDto;
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
                Teachers = SubjectModel.TeacherSubjects.Select(x => new GetTeacherNameDto
                {
                    Id = x.Teacher.Id,
                    Name = x.Teacher.Name,
                    Surname = x.Teacher.Surname,
                }).ToList(),

            };
        }
       
        public static Subject ToSubjectModel(this CreateSubjectDto SubjectDto)
        {
            return new Subject
            {
               
                Name = SubjectDto.Name,
               
            };
        }

        public static GetSubjectNameDto ToSubjectNameDto(this Subject SubjectModel)
        {
            return new GetSubjectNameDto
            {
                Id = SubjectModel.Id,
                Name = SubjectModel.Name,

            };
        }
    }
}
