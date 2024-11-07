/*using learngate_api.Contracts;
using learngate_api.DTOs.AssignmentDto;
using learngate_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/assignment")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAssignment()
        {
            try
            {   
                var assignments = await _assignmentRepository.GetAllAssignmentAsync();
                return Ok(assignments.Select(x => x.ToAssignmentDto()));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getBy/{Id}")]

        public async Task<IActionResult> GetAssignmentById([FromRoute] int Id )
        {
            try
            {
                var assignment = await _assignmentRepository.GetAssignmentByIdAsync(Id);
                if (assignment == null)
                {
                    return NotFound();
                }
                var assignmentDto = assignment.ToAssignmentDto();
                return Ok(assignmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentDto assignmentDto)
        {
            try
            {
                var newAssignment = await _assignmentRepository.CreateAssignmentAsync(assignmentDto.ToAssignmentModel());
                return Ok(newAssignment.ToAssignmentDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateAssignment([FromRoute] int Id, [FromBody] UpdateAssignmentDto assignmentDto)
        {
            try
            {
                var excistingAssignment = await _assignmentRepository.GetAssignmentByIdAsync(Id);
                if(excistingAssignment == null)
                {
                    return NotFound();
                }
                excistingAssignment.Title = assignmentDto.Title;
                excistingAssignment.StartDate = assignmentDto.StartDate;
                excistingAssignment.DueDate = assignmentDto.DueDate;
                excistingAssignment.LessonID = assignmentDto.LessonID;

               var updatedAssignmentModel = await _assignmentRepository.UpdateAssignmentAsync(excistingAssignment); 
               var UpdatedAssignmentDto = updatedAssignmentModel.ToAssignmentDto();
               return Ok(UpdatedAssignmentDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteAssignment([FromRoute] int Id)
        {
            try
            {
                var deletedAssignmnet = await _assignmentRepository.DeleteAssignmentAsync(Id);
                var deletedAssignmentDto = deletedAssignmnet.ToAssignmentDto();
                return Ok(deletedAssignmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
*/



