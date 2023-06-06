using AutoMapper;
using Tree.Application.NodeDto;
using Tree.Domain.Entities;

namespace Tree.Application.Mappings
{
    public class TreeMappingProfile : Profile
    {
        public TreeMappingProfile()
        {
            CreateMap<EditNodeDto, Domain.Entities.Node>();
            CreateMap<CreateNodeDto, Domain.Entities.Node>();
            CreateMap<Node, NodeDto.NodeDto>();
        }
    }
}
