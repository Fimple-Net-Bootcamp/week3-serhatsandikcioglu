using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActivityService(IActivityRepository activityRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ActivityDTO Add(ActivityCreateDTO activityCreateDTO)
        {
            Activity activity = _mapper.Map<Activity>(activityCreateDTO);
            _activityRepository.Add(activity);
            _unitOfWork.SaveChanges();
            ActivityDTO activityDTO = _mapper.Map<ActivityDTO>(activity);
            return activityDTO;
            
        }

        public List<ActivityDTO> GetById(int petId)
        {
           List<Activity> activities = _activityRepository.GetById(petId);
            List<ActivityDTO> activityDTOs = _mapper.Map<List<ActivityDTO>>(activities);
            return activityDTOs;
        }
    }
}
