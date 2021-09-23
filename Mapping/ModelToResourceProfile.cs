using AutoMapper;
using DividendScanner.Domain.Model;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Company, CompanyResource>()
                .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Sector.Name));
            CreateMap<CompanyResource, Company>();
            CreateMap<Sector, SectorResource>();
            CreateMap<SectorResource, Sector>();
        }
    }
}
