using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/activities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IPetService _petService;

        public ActivityController(IActivityService activityService, IPetService petService)
        {
            _activityService = activityService;
            _petService = petService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ActivityCreateDTO activityCreateDTO)
        {
            bool petExist = _petService.IsExist(activityCreateDTO.PetId);
            if (petExist)
            {
            ActivityDTO activityDTO = _activityService.Add(activityCreateDTO);
            return StatusCode(201,activityDTO);
            }
            return NotFound();
        }
        [HttpGet("{petId}")]
        public IActionResult GetById(int petId)
        {
            List<ActivityDTO> activityDTOs = _activityService.GetById(petId);
            if (activityDTOs != null)
            {
                return Ok(activityDTOs);
            }
            return NotFound();
        }
    }
}
