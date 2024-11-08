using learngate_api.DTOs.AttendanceDto;
using learngate_api.DTOs.LessonDto;
using learngate_api.DTOs.StudentDto;
using learngate_api.Models;

namespace learngate_api.Mappers
{
    public static class AttendanceMapper
    {
        public static GetAttendanceDto ToAttendanceDto(this Attendance attendanceModel)
        {
            return new GetAttendanceDto
            {
                Id = attendanceModel.Id,
                Date = attendanceModel.Date,
                Present = attendanceModel.Present,
                StudentId = attendanceModel.StudentId,
                LessonId = attendanceModel.LessonId,
                Student = new GetStudentNameDto
                {
                    Id = attendanceModel.Student.Id,
                    Name = attendanceModel.Student.Name,
                    Surname = attendanceModel.Student.Surname,
                },
                Lesson = new GetLessonNameDto
                {
                    Id = attendanceModel.Lesson.Id,
                    Name = attendanceModel.Lesson.Name,
               }
            };
        }

        public static Attendance ToAttendanceModel(this CreateAttendanceDto attendanceDto)
        {
            return new Attendance
            {

                Date = attendanceDto.Date,
                Present = attendanceDto.Present,
                StudentId = attendanceDto.StudentId,
                LessonId = attendanceDto.LessonId,
      
            };
        }

    }
}
