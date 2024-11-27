using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.LessonDto;
using learngate_api.DTOs.SubjectDto;
using learngate_api.DTOs.TeacherDto;
using learngate_api.Models;

namespace learngate_api.Mappers
{
    public static  class LessonMapper
    {
       public static GetLessonDto ToLessonDto(this Lesson lessonModel)
        {
            return new GetLessonDto
            {
                Id = lessonModel.Id,
                Name = lessonModel.Name,
                Day = lessonModel.Day,
                StartTime = lessonModel.StartTime,
                EndTime = lessonModel.EndTime,
                SubjectId = lessonModel.SubjectId,
                
                ClassId = lessonModel.ClassId,
                TeacherId = lessonModel.TeacherId,
                Subject = new GetSubjectNameDto
                {
                    Id = lessonModel.Subject.Id,
                    Name = lessonModel.Subject.Name,    
                },
                Class = new GetClassNameDto
                {
                    Id = lessonModel.Class.Id,
                    Name = lessonModel.Class.Name,
                },
                
                Teacher = new GetTeacherNameDto
                {
                    Id = lessonModel.Teacher.Id,
                    Name = lessonModel.Teacher.Name,
                    Surname = lessonModel.Teacher.Surname
                },
            };
        }

        public static Lesson ToLessonModel (this CreateLessonDto lessonDto)
        {
            return new Lesson
            {
                Name = lessonDto.Name,
                Day = lessonDto.Day,
                StartTime = lessonDto.StartTime,
                EndTime = lessonDto.EndTime,
                SubjectId = lessonDto.SubjectId,
                ClassId = lessonDto.ClassId,
                TeacherId = lessonDto.TeacherId,

            };
        }


        public static GetByClassSubjectIdDto ToLessonsForSubjectDto(this Lesson lessonModel)
        {
            return new GetByClassSubjectIdDto
            {
                Id = lessonModel.Id,
                Name = lessonModel.Name,
                ClassSubjectId = lessonModel.ClassSubjectId,
               
            };
        }
    }
}





