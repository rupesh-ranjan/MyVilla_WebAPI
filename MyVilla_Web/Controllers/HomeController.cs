using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyVilla_Web.Models;
using MyVilla_Web.Models.Dto;
using MyVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MyVilla_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public HomeController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> villaList = new();
            var response = await _villaService.GetALLAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(villaList);
        }

    }
}