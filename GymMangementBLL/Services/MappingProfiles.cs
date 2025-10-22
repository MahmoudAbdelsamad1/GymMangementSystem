using AutoMapper;
using GymMangementBLL.ViewModels.SessionsViewModels;
using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SessionModel,SessionViewModel>().ForMember(dest => dest.CategoryName, Options => Options.MapFrom(src => src.SessionCategory.Name))
                             .ForMember(dest => dest.TrainerName, Options => Options.MapFrom(src => src.SessionTrainer.Name))
                             .ForMember(dest => dest.AvailableSlots, Options => Options.Ignore());
        }
    }
}
