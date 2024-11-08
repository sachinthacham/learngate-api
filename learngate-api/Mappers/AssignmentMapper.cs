/*using learngate_api.DTOs.AssignmentDto;
using learngate_api.Models;

namespace learngate_api.Mappers
{
    public static class AssignmentMapper
    {
        public static GetAssignmentDto ToAssignmentDto(this Assignment assignmentModel)
        {
            return new GetAssignmentDto
            {
                Id = assignmentModel.Id,
                Title = assignmentModel.Title,
                StartDate = assignmentModel.StartDate,
                DueDate = assignmentModel.DueDate,
                LessonID = assignmentModel.LessonID,
                Lesson = assignmentModel.Lesson,
            };
        }

        public static Assignment ToAssignmentModel(this CreateAssignmentDto assignmentDto)
        {
            return new Assignment
            {
           
                Title = assignmentDto.Title,
                StartDate = assignmentDto.StartDate,
                DueDate = assignmentDto.DueDate,
                LessonID = assignmentDto.LessonID,
              
            };
        }
    }
}*/
