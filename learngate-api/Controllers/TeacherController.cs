using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.TeacherDto;
using learngate_api.Mappers;
using learngate_api.Models;
using learngate_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace learngate_api.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

       

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllStudent(
          [FromQuery] string? search = null,
          [FromQuery] int? subjectId = null,
          [FromQuery] int pageNumber = 1,
          [FromQuery] int pageSize = 10)
        {
            try
            {
                var allTeachers = await _teacherRepository.GetAllTeachersAsync(search, subjectId, pageNumber, pageSize);

                var teacherDtos = allTeachers.Select(s => s.ToTeacherDto());

                return Ok(new
                {
                    Data = teacherDtos,
                    Pagination = new
                    {
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalCount = await _teacherRepository.GetTotalCountAsyncForFilter(search, subjectId) // Add total count for pagination
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









        [HttpGet("{teacherId}/subjects")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjectsByTeacherId(int teacherId)
        {
            var subjects = await _teacherRepository.GetSubjectsByTeacherIdAsync(teacherId);
            if (subjects == null)
                return NotFound();

            return Ok(subjects);
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetTeacherById(int Id)
        {
            try
            {
                var teacher = await _teacherRepository.GetTeacherByIdAsync(Id);
                if(teacher == null)
                {
                    return NotFound();
                }
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherDto teacherDto)
        {
            try
            {
                var newTeacher = await _teacherRepository.CreateTeacherAsync(teacherDto.ToTeacherModel(),teacherDto.SubjectIds);
                var newTeacherDto = newTeacher.ToTeacherDto();
                return CreatedAtAction(nameof(GetTeacherById), new { id = newTeacher.Id }, newTeacherDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateTeacher([FromRoute] int Id, [FromBody] UpdateTeacherDto updateDto)
        {
            try
            {
                var excistingModel = await _teacherRepository.GetTeacherByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no teacher found");
                }
                excistingModel.UserName = updateDto.UserName;
                excistingModel.Name = updateDto.Name;
                excistingModel.Surname = updateDto.Surname;
                excistingModel.Email = updateDto.Email;
                excistingModel.Phone = updateDto.Phone;
                excistingModel.Address = updateDto.Address;
                excistingModel.Img = updateDto.Img;
                excistingModel.BloodType = updateDto.BloodType;
                excistingModel.Sex = updateDto.Sex;

                await _teacherRepository.UpdateTeacherAsync(excistingModel);
                var teacherDto = excistingModel.ToTeacherDto();
                return Ok(teacherDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteTeacher([FromRoute] int Id)
        {
            try
            {

                var deletedTeacher = await _teacherRepository.DeleteTeacherAsync(Id);
                var deletedTeacherDto = deletedTeacher.ToTeacherDto();
                return Ok(deletedTeacherDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
