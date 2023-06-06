using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tree.Application.NodeDto;
using Tree.Domain.Entities;
using Tree.Domain.Interfaces;

namespace Tree.Application.Services
{
    public class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        private readonly IMapper _mapper;
        public TreeService(ITreeRepository treeRepository, IMapper mapper)
        {
            _treeRepository = treeRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateNodeDto createNodeDto)
        {
            var tree = _mapper.Map<Domain.Entities.Node>(createNodeDto);

            await _treeRepository.Create(tree);
        }

        public async Task<bool> DeleteNode(int id)
        {
            var node = await _treeRepository.GetNodeById(id);

            if (node == null)
            {
                return false;
            }

            await _treeRepository.DeleteNode(node);

            return true;
        }

        public async Task<bool> IsPossible(Node node, Node targetNode)
        {
            var nodeWithChildren = await _treeRepository.GetNodeWithChildren(node);

            if (nodeWithChildren?.Children.FirstOrDefault() is null)
            {
                return true;
            }

            if (nodeWithChildren.Children.Contains(targetNode))
            {
                return false;
            }

            foreach (var child in nodeWithChildren.Children)
            {
                if (!await IsPossible(child, targetNode))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> EditNode(EditNodeDto dto)
        {
            if (!dto.IsValid())
            {
                return false;
            }

            if (dto.NewName is not null)
            {
                var node = await _treeRepository.GetNodeById(dto.ToEditNodeId.Value);

                if (node == null)
                {
                    return false;
                }

                node.Name = dto.NewName;

                await _treeRepository.UpdateNode(node);
            }

            if (dto.ToEditNode is not null)
            {
                var node = await _treeRepository.GetNodeById(dto.ToEditNodeId.Value);

                if (node == null)
                {
                    return false;
                }

                var targetParentId = int.Parse(dto.ToEditNode.Split(".")[0]);

                var targetParentNode = await _treeRepository.GetNodeById(targetParentId);

                if (targetParentNode == null)
                {
                    return false;
                }

                if (node == targetParentNode)
                {
                    return false;
                }

                if (!await IsPossible(node, targetParentNode))
                {
                    return false;
                }

                targetParentNode.Children.Add(node);

                await _treeRepository.UpdateNode(targetParentNode);
            }

            return true;
        }

        public async Task<List<NodeDto.NodeDto>> GetNodesOrderedById()
        {
            var tree = await _treeRepository.GetNodesOrderedById();
            var dtos = _mapper.Map<List<NodeDto.NodeDto>>(tree);

            return dtos;
        }
    }
}
