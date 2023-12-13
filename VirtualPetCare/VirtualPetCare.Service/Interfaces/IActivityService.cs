using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs;

namespace VirtualPetCare.Service.Interfaces
{
    public interface IActivityService
    {
        ActivityDTO Add(ActivityCreateDTO activityCreateDTO);
        List<ActivityDTO> GetById(int petId);
    }
}
