using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.StudentDto;
using learngate_api.Mappers;
using learngate_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace learngate_api.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllStudent(
            [FromQuery] string? search = null,
            [FromQuery] int? classId = null,
            [FromQuery] int? gradeId = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var allStudents = await _studentRepository.GetAllStudentsAsync(search, classId, gradeId, pageNumber, pageSize);

                var studentDtos = allStudents.Select(s => s.ToStudentDto());

                return Ok(new
                {
                    Data = studentDtos,
                    Pagination = new
                    {
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalCount = await _studentRepository.GetTotalCountAsyncForFilter(search, classId, gradeId) // Add total count for pagination
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("getby/{username}")]

        public async Task<IActionResult> GetStudentById(string username)
        {
            try
            {
                var student = await _studentRepository.GetStudentByIdAsync(username);
                if(student == null)
                {
                    return NotFound("There are no students");
                }
                return Ok(student.ToStudentProfileDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto studentDto)
        {
            try
            {
                var newStudent = await _studentRepository.CreateStudentAsync(studentDto.ToStudentModel());
                var newStudentDto = newStudent.ToStudentDto();
                return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudentDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateAnnouncement([FromRoute] string username, [FromBody] UpdateStudentDto updateDto)
        {
            try
            {
                var excistingModel = await _studentRepository.GetStudentByIdAsync(username);
                if (excistingModel == null)
                {
                    return NotFound("There are no Student found");
                }
                excistingModel.UserName = updateDto.UserName;
                excistingModel.Name = updateDto.Name;
                excistingModel.Surname = updateDto.Surname;
                excistingModel.Email = updateDto.Email;
                excistingModel.Phone = updateDto.Phone;
                excistingModel.Address = updateDto.Address;
                excistingModel.Img = updateDto.Img;
                excistingModel.BloodType = updateDto.BloodType;
                excistingModel.GradeId = updateDto.GradeId;
                excistingModel.Sex = updateDto.Sex;
                excistingModel.ParentId = updateDto.ParentId;
                excistingModel.ClassId = updateDto.ClassId;

                await _studentRepository.UpdateStudentAsync(excistingModel);
                var studentDto = excistingModel.ToStudentDto();
                return Ok(studentDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] int Id)
        {
            try
            {

                var deletedStudent = await _studentRepository.DeleteStudentAsync(Id);
                var deletedStudentDto = deletedStudent.ToStudentDto();
                return Ok(deletedStudentDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
