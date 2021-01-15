using AutoMapper;
using niyw.cotroller.AgentPools;

namespace niyw.cotroller
{
    public class cotrollerApplicationAutoMapperProfile : Profile
    {
        public cotrollerApplicationAutoMapperProfile()
        {
            CreateMap<Pool, PoolDto>();
            CreateMap<CreateUpdatePoolDto, Pool>();
            CreateMap<PoolEntity, CreateUpdatePoolDto>().ForMember("PoolId", opt=>opt.MapFrom(src=>src.Id));
        }
    }
}
