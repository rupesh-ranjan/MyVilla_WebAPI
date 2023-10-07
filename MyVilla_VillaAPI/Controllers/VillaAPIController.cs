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
        public VillaAPIController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(_dbContext.Villas.ToList());
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                //_logger.Log("Get Villa Error with Id " + id, "error");
                return BadRequest();
            }
            var vila =  _dbContext.Villas.FirstOrDefault(u => u.Id == id);
            if (vila == null) 
            {
                return NotFound();
            }
            return Ok(vila);
        }
        #endregion

        #region Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (_dbContext.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already Exists");
                return BadRequest(ModelState);
            }
            if(villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Villa villa = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                ImageUrl = villaDTO.ImageUrl,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Amenity = villaDTO.Amenity
            };
            _dbContext.Villas.Add(villa);
            _dbContext.SaveChanges();
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
        }
        #endregion

        #region Delete
        [HttpDelete("{id:int}", Name ="DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0) return BadRequest();
            var villa = _dbContext.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null) return NotFound();
            _dbContext.Villas.Remove(villa);
            _dbContext.SaveChanges();
            return NoContent();
        }
        #endregion
        
        #region Update
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id) return BadRequest();
            Villa model = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                ImageUrl = villaDTO.ImageUrl,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Amenity = villaDTO.Amenity
            };
            _dbContext.Villas.Update(model);
            _dbContext.SaveChanges();
            return NoContent();
        }
        #endregion

        #region Patch
        [HttpPatch("{id:int}", Name = "PatchVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PartialUpdateVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0) return BadRequest();
            var villa = _dbContext.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (villa == null) return BadRequest();
            VillaDTO villaDTO = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                ImageUrl = villa.ImageUrl,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                Amenity = villa.Amenity
            };
            patchDTO.ApplyTo(villaDTO, ModelState);
            if (!ModelState.IsValid) return BadRequest();
            Villa model = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                ImageUrl = villaDTO.ImageUrl,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Amenity = villaDTO.Amenity
            };
            _dbContext.Villas.Update(model);
            _dbContext.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
