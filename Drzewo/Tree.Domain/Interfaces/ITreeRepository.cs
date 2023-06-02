using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Domain.Entities;

namespace Tree.Domain.Interfaces
{
    public interface ITreeRepository
    {
        Task Create(Domain.Entities.Node tree);
        Task<bool> Delete(int id);
        Task<Node> GetNodeWithChildren(Node node);
        Task<Node> GetNodeById(int id);
        Task DeleteNode(Node node);
        Task<Node> GetNodeByName(string name);
        Task UpdateNode(Node node);
        Task<Node> GetNodeWithChildren(int id);
    }
}
