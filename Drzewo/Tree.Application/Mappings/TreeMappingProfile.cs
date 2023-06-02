using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Application.NodeDto;
using Tree.Application.Tree;
using Tree.Domain.Entities;

namespace Tree.Application.Mappings
{
    public class TreeMappingProfile : Profile
    {
        public TreeMappingProfile()
        {
            CreateMap<EditNodeDto, Domain.Entities.Node>();
            CreateMap<CreateNodeDto, Domain.Entities.Node>();
        }
    }
}
