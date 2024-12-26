using FirstAPI.DTOs.Color;
using FirstAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColorsCategories : ControllerBase
    {
        private readonly IColorService _service;

        public ColorsCategories(IColorService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult>Get(int page=1,int take=1)
        {
            return Ok(await _service.GetAllAsync(page,take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            if (id < 1) return BadRequest();
            var colorDTO=await _service.GetByIdAsync(id);
            if (colorDTO == null) return NotFound();
            return StatusCode(StatusCodes.Status200OK,colorDTO);

        }


        [HttpPost]
        public async Task<IActionResult>Create([FromForm]CreateColorDTO colorDTO)
        {
            if(!await _service.CreateAsync(colorDTO)) return BadRequest();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, [FromForm]UpdateColorDTO colorDTO)
        {
            if(id<1) return BadRequest();
            await _service.UpdateAsync(id, colorDTO);   
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _service.DeleteAsync(id);
            return NoContent();
        }


    }
}
