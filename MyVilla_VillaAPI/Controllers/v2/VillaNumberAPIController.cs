using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVilla_VillaAPI.Models;
using MyVilla_VillaAPI.Models.Dto;
using MyVilla_VillaAPI.Repository.IRepostiory;
using System.Net;

namespace MyVilla_VillaAPI.Controllers.v2
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaNumberAPIController(IVillaRepository dbVilla, IVillaNumberRepository dbVillaNumber, IMapper mapper)
        {
            _dbVilla = dbVilla;
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _response = new();
        }

        #region Get

        [HttpGet("GetString")]
        //[MapToApiVersion("2.0")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        #endregion
    }
}
