using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.LessonDto;
using learngate_api.Mappers;
using learngate_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/lesson")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        [HttpGet]
        [Route("getAll")] 

        public async Task<IActionResult> GetAllAnnouncements()
        {
            try
            {
                var allLessons = await _lessonRepository.GetAllLessonsAsync();
                var lessonDto = allLessons.Select(s => s.ToLessonDto());
                return Ok(lessonDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getlessons/{classSubjectId}")] 

        public async Task<IActionResult> GetAllAnnouncements([FromRoute] int classSubjectId)
        {
            try
            {
                var allLessons = await _lessonRepository.GetLessonByClassSubjectIdAsync(classSubjectId);
                var lessonDto = allLessons.Select(s => s.ToLessonsForSubjectDto());
                return Ok(lessonDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetLessonById(int Id)
        {
            try
            {

                var lesson = await _lessonRepository.GetLessonByIdAsync(Id);
                if(lesson == null)
                {
                    return NotFound("There are no lessons");
                }
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateLesson([FromBody] CreateLessonDto lessonDto)
        {
            try
            {
                var newLesson = await _lessonRepository.CreateLessonAsync(lessonDto.ToLessonModel());
                var newLessonDto = newLesson.ToLessonDto();
                return CreatedAtAction(nameof(GetLessonById), new { id = newLesson.Id }, newLessonDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateLesson([FromRoute] int Id, [FromBody] UpdateLessonDto updateDto)
        {
            try
            {
                var excistingModel = await _lessonRepository.GetLessonByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no lessons found");
                }
                excistingModel.Name = updateDto.Name;
                excistingModel.Day = updateDto.Day;
                excistingModel.StartTime = updateDto.StartTime;
                excistingModel.EndTime = updateDto.EndTime;
                excistingModel.SubjectId = updateDto.SubjectId;
                excistingModel.ClassId = updateDto.ClassId;
                excistingModel.TeacherId = updateDto.TeacherId;

                await _lessonRepository.UpdateLessonAsync(excistingModel);
                var lessonDto = excistingModel.ToLessonDto();
                return Ok(lessonDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteLesson([FromRoute] int Id)
        {
            try
            {

                var deletedLesson = await _lessonRepository.DeleteLessonAsync(Id);
                var deletedLessonDto = deletedLesson.ToLessonDto();
                return Ok(deletedLessonDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
