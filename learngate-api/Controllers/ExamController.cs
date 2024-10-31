using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.ExamDto;
using learngate_api.Mappers;
using learngate_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/exam")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepository;
        public ExamController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllAnnouncements()
        {
            try
            {
                var allExams = await _examRepository.GetAllExamsAsync();
                var ExamDto = allExams.Select(s => s.ToExamDto());
                return Ok(ExamDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetExamById(int Id)
        {
            try
            {
                var exam = await _examRepository.GetExamByIdAsync(Id);
                return Ok(exam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateExam([FromBody] CreateExamDto examDto)
        {
            try
            {
                var newExam = await _examRepository.CreateExamAsync(examDto.ToExamModel());
                var newExamDto = newExam.ToExamDto();
                return CreatedAtAction(nameof(GetExamById), new { id = newExam.Id }, newExamDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateAnnouncement([FromRoute] int Id, [FromBody] UpdateExamDto updateDto)
        {
            try
            {
                var excistingModel = await _examRepository.GetExamByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no Exam found");
                }
                excistingModel.Title = updateDto.Title;
                excistingModel.StartTime = updateDto.StartTime;
                excistingModel.EndTime = updateDto.EndTime;
                excistingModel.LessonID = updateDto.LessonID;

                await _examRepository.UpdateExamAsync(excistingModel);
                var examDto = excistingModel.ToExamDto();
                return Ok(examDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteExams([FromRoute] int Id)
        {
            try
            {

                var deletedExam = await _examRepository.DeleteExamAsync(Id);
                var deletedExamDto = deletedExam.ToExamDto();
                return Ok(deletedExamDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
