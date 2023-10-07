using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVilla_VillaAPI.Data;
using MyVilla_VillaAPI.Logging;
using MyVilla_VillaAPI.Models;
using MyVilla_VillaAPI.Models.Dto;

namespace MyVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VillaAPIController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            IEnumerable<Villa> villaList = await _dbContext.Villas.ToListAsync();
            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                //_logger.Log("Get Villa Error with Id " + id, "error");
                return BadRequest();
            }
            var villa = await _dbContext.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null) 
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villa));
        }
        #endregion

        #region Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO createDTO)
        {
            if (await _dbContext.Villas.FirstOrDefaultAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already Exists");
                return BadRequest(ModelState);
            }
            if(createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Villa villa = _mapper.Map<Villa>(createDTO);
            await _dbContext.Villas.AddAsync(villa);
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }
        #endregion

        #region Delete
        [HttpDelete("{id:int}", Name ="DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0) return BadRequest();
            var villa = await _dbContext.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null) return NotFound();
            _dbContext.Villas.Remove(villa);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        #endregion
        
        #region Update
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id) return BadRequest();
            Villa villa = _mapper.Map<Villa>(updateDTO);    
            _dbContext.Villas.Update(villa);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        #endregion

        #region Patch
        [HttpPatch("{id:int}", Name = "PatchVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PartialUpdateVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0) return BadRequest();
            var villa = await _dbContext.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null) return BadRequest();
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
            patchDTO.ApplyTo(villaDTO, ModelState);
            if (!ModelState.IsValid) return BadRequest();
            Villa model = _mapper.Map<Villa>(villaDTO);
            _dbContext.Villas.Update(model);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        #endregion
    }
}
