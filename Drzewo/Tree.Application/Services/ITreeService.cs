using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Application.NodeDto;
using Tree.Domain.Entities;

namespace Tree.Application.Services
{
    public interface ITreeService
    {
        Task Create(CreateNodeDto model);
        Task<bool> IsPossible(Node node, Node targetNode);
        Task<bool> DeleteNode(int id);
        Task<bool> EditNode(EditNodeDto dto);
        Task<List<NodeDto.NodeDto>> GetNodesOrderedById();
    }
}
