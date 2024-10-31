using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.ParentDto;
using learngate_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace learngate_api.Controllers
{
    [Route("api/parent")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;
        public ParentController(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllParents()
        {
            try
            {
                var allParent = await _parentRepository.GetAllParentsAsync();
                var ParentDto = allParent.Select(s => s.ToParentDto());
                return Ok(ParentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetParentById(int Id)
        {
            try
            {

                var parent = await _parentRepository.GetParentByIdAsync(Id);
                if(parent == null)
                {
                    return NotFound();
                }
                return Ok(parent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateParent([FromBody] CreateParentDto parentDto)
        {
            try
            {
                var newParent = await _parentRepository.CreateParentAsync(parentDto.ToParentModel());
                var newParentDto = newParent.ToParentDto();
                return CreatedAtAction(nameof(GetParentById), new { id = newParent.Id }, newParentDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateParent([FromRoute] int Id, [FromBody] UpdateParentDto updateDto)
        {
            try
            {
                var excistingModel = await _parentRepository.GetParentByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no parent found");
                }
                excistingModel.UserName = updateDto.UserName;
                excistingModel.Name = updateDto.Name;
                excistingModel.Surname = updateDto.Surname;
                excistingModel.Email = updateDto.Email;
                excistingModel.Phone = updateDto.Phone;
                excistingModel.Address = updateDto.Address;

                await _parentRepository.UpdateParentAsync(excistingModel);
                var parentDto = excistingModel.ToParentDto();
                return Ok(parentDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteParent([FromRoute] int Id)
        {
            try
            {

                var deletedParent = await _parentRepository.DeleteParentAsync(Id);
                var deletedParentDto = deletedParent.ToParentDto();
                return Ok(deletedParentDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
