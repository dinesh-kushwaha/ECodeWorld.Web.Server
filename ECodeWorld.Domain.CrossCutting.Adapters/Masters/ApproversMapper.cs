using AutoMapper;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.CustomModels;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{

    public class ApproversMapper : IApproversMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ApproverTypesDto, ApproverTypes>();
                    cfg.CreateMap<ApproverTypes, ApproverTypesDto>();

                    cfg.CreateMap<ApproversMembersDto, ApproversMembersModel>();
                    cfg.CreateMap<ApproversMembersModel, ApproversMembersDto>();

                }).CreateMapper();
            }
        }
    }
}
