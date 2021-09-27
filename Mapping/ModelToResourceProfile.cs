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
            CreateMap<Company, CompanyResource>();
            CreateMap<CompanyResource, Company>()
                 .ForMember(dest => dest.ISIN, opt => opt.MapFrom(src => src.ISIN))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Ticker, opt => opt.MapFrom(src => src.Ticker))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<Sector, SectorResource>();
            CreateMap<SectorResource, Sector>();
        }
    }
}
