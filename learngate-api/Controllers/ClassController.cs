using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.ClassDto;
using learngate_api.Mappers;
using learngate_api.Models;
using learngate_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/class")]
    [ApiController]
    
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllClasses()
        {
            try
            {
                var classes = await _classRepository.GetAllClassesAsync();
                var ClassesDto = classes.Select(s => s.ToClassDto());
                return Ok(ClassesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("getBy/{Id}")]
        
        public async Task<IActionResult> GetClassById([FromRoute] int Id)
        {
            try
            {
                var getclass = await _classRepository.GetClassByIdAsync(Id);
                if (getclass == null)
                {
                    return NotFound();
                }
                var getClassDto = getclass.ToClassDto;
                return Ok(getClassDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("getbyGradeId/{gradeId}")]
        public async Task<IActionResult> GetClassesByGradeId([FromRoute] int gradeId)
        {
            try
            {
                var getclasses = await _classRepository.GetClassesByGradeIdAsync(gradeId);
               
                var getClassDto = getclasses.Select(s => s.ToClassDto());
                return Ok(getClassDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateClass([FromBody] CreateClassDto classDto)
        {
            try
            {
                var newClass = await _classRepository.CreateClassAsync(classDto.ToClassModel());
                var newClassDto = newClass.ToClassDto();
                return CreatedAtAction(nameof(GetClassById), new { id = newClass.Id }, newClassDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateClass([FromRoute] int Id, [FromBody] UpdateClassDto updateDto)
        {
            try
            {
                var excistingModel = await _classRepository.GetClassByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no Announcement found");
                }
                excistingModel.Name = updateDto.Name;
                excistingModel.Capacity = updateDto.Capacity;
                excistingModel.SupervisorId = updateDto.SupervisorId;
                excistingModel.GradeId = updateDto.GradeId;

                await _classRepository.UpdateClassAsync(excistingModel);
                var classDto = excistingModel.ToClassDto();
                return Ok(classDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteAnnouncement([FromRoute] int Id)
        {
            try
            {

                var deletedClass = await _classRepository.DeleteClassAsync(Id);
                var deletedClassDto = deletedClass.ToClassDto();
                return Ok(deletedClassDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
