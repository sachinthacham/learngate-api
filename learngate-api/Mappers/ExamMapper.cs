using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.ExamDto;
using learngate_api.DTOs.LessonDto;
using learngate_api.DTOs.SubjectDto;
using learngate_api.Models;

namespace learngate_api.Mappers
{
    public static class ExamMapper
    {
        public static GetExamDto ToExamDto(this Exam examModel)
        {
            return new GetExamDto
            {
                  Id = examModel.Id,
                  Title = examModel.Title,
                  StartTime = examModel.StartTime,
                  EndTime = examModel.EndTime,
                  LessonID = examModel.LessonID,
                  SubjectId = examModel.SubjectId,
                  Lesson = new GetLessonNameDto
                  {
                      Id = examModel.Lesson.Id,
                      Name = examModel.Lesson.Name,
                  },
                  Subject = new GetSubjectNameDto
                  {
                      Id = examModel.Subject.Id,
                      Name = examModel.Subject.Name,
                  },
                  Class = new GetClassNameDto
                {
                      Id = examModel.Class.Id,
                      Name = examModel.Class.Name,
                }
            };
        }

        public static Exam ToExamModel(this CreateExamDto examDto)
        {
            return new Exam
            {
                Title = examDto.Title,
                StartTime = examDto.StartTime,
                EndTime = examDto.EndTime,
                LessonID = examDto.LessonID,
                
            };
        }
    }
}
