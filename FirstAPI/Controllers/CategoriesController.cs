
using FirstAPI.Repositories.Implementations;
using FirstAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
           
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1,int take=3)
        {

          // var categories=await _repository.GetAll(c=>c.Name.Contains("Gul")).ToListAsync();
           
            int skipValue=(page-1)*take;
            var categories = await _repository.GetAll(c=>c.Name.Contains("Test"),c=>c.Name,skipValue,take,true,true,"Products").ToListAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if ( id < 1) return BadRequest();
            Category category=await _repository.GetByIdAsync(id);
            if(category == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, category);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDTO categoryDTO)
        {
            Category category = new Category { 
            
                Name = categoryDTO.Name
            };
           await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

           // return Created();
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) return NotFound();
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,string name)
        {
            if (id < 1) return BadRequest();
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) return NotFound();
            category.Name = name; 
            
           _repository.Update(category);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
