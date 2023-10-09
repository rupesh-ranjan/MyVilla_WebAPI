using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyVilla_Web.Models;
using MyVilla_Web.Models.Dto;
using MyVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System.Reflection;

namespace MyVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> villaList = new();
            var response = await _villaService.GetALLAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(villaList);
        }

        public IActionResult CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                    return RedirectToAction(nameof(IndexVilla));
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateVilla(int villId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villId);
            if (response != null && response.IsSuccess)
            {
                VillaDTO villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaUpdateDTO>(villa));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                    return RedirectToAction(nameof(IndexVilla));
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteVilla(int villId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villId);
            if (response != null && response.IsSuccess)
            {
                VillaDTO villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(villa);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO model)
        {
            var response = await _villaService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(IndexVilla));
            return View(model);
        }
    }
}
