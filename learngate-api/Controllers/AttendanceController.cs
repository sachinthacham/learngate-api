using learngate_api.Contracts;
using learngate_api.DTOs.AttendanceDto;
using learngate_api.Mappers;
using learngate_api.Models;
using learngate_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace learngate_api.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllAttendance()
        {
            try
            {
                var allAttendance = await _attendanceRepository.GetAllAttendanceAsync();
                var AttendanceDto = allAttendance.Select(s => s.ToAttendanceDto());
                return Ok(AttendanceDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetAttendanceById(int Id)
        {
            try
            {
                var attendance = await _attendanceRepository.GetAttendanceByIdAsync(Id);
                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAttendanceDto attendanceDto)
        {
            try
            {
                var newAttendance = await _attendanceRepository.CreateAttendanceAsync(attendanceDto.ToAttendanceModel());
                var newAttendanceDto = newAttendance.ToAttendanceDto();
                return CreatedAtAction(nameof(GetAttendanceById), new { id = newAttendance.Id }, newAttendanceDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateAttendance([FromRoute] int Id, [FromBody] UpdateAttendanceDto updateDto)
        {
            try
            {
                var excistingModel = await _attendanceRepository.GetAttendanceByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no Attendance found");
                }
               
                excistingModel.Date = updateDto.Date;
                excistingModel.Present = updateDto.Present;
                excistingModel.StudentId = updateDto.StudentId;
                excistingModel.LessonId = updateDto.LessonId;

                await _attendanceRepository.UpdateAttendanceAsync(excistingModel);
                var attendanceDto = excistingModel.ToAttendanceDto();
                return Ok(attendanceDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteAttendance([FromRoute] int Id)
        {
            try
            {

                var deletedAttendance = await _attendanceRepository.DeleteAttendanceAsync(Id);
                var deletedAnnouncementDto = deletedAttendance.ToAttendanceDto();
                return Ok(deletedAnnouncementDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
