
using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.ExamDto;
using learngate_api.DTOs.ResultDto;

using learngate_api.DTOs.StudentDto;
using learngate_api.DTOs.SubjectDto;
using learngate_api.Models;
using System.Reflection;

namespace learngate_api.Mappers
{
    public static class ResultMapper
    {
        public static GetResultDto ToResultDto(this Result resultModel)
        {
            return new GetResultDto
            {
                Id = resultModel.Id,
                Score = resultModel.Score,
                ExamId = resultModel.ExamId,
                StudentId = resultModel.StudentId,
                Exam = new GetExamNameDto
                {
                    Id = resultModel.Exam.Id,
                    Title = resultModel.Exam.Title
                },

                Student =  new GetStudentNameDto
                {
                    Id = resultModel.Student.Id, 
                    Name = resultModel.Student.Name, 
                    Surname = resultModel.Student.Surname 
                },
                Class = new GetClassNameDto
                {
                    Id = resultModel.Class.Id,
                    Name = resultModel.Class.Name,
                },
                Subject = new GetSubjectNameDto
                {
                    Id = resultModel.Subject.Id,
                    Name = resultModel.Subject.Name,
                }

            };
        }

        public static Result ToResultModel(this CreateResultDto resultDto)
        {
            return new Result
            {
             
                Score = resultDto.Score,
                ExamId = resultDto.ExamId,
                SubjectId = resultDto.StudentId,
                StudentId = resultDto.StudentId,
            };
        }
    }
}
