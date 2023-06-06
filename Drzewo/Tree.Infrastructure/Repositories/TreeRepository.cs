using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Domain.Entities;
using Tree.Domain.Interfaces;
using Tree.Infrastructure.Persistence;

namespace Tree.Infrastructure.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private readonly TreeDbContext _dbContext;

        public TreeRepository(TreeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.Node tree)
        {
            var nodes = await _dbContext
                .Nodes
                .ToListAsync();

            var node = new Node()
            {
                Name = tree.Name
            };

            if (tree.ParentNode is null)
            {
                if (nodes.Any())
                {
                    throw new Exception("You must select a parent node.");
                }
                await _dbContext.Nodes.AddAsync(node);
                await _dbContext.SaveChangesAsync();
            }

            var parentNode = _dbContext
                .Nodes
                .FirstOrDefault(n => n.Id == int.Parse(tree.ParentNode));

            if (parentNode == null)
            {
                throw new Exception("Parent node not found");
            }

            parentNode.Children.Add(node);
            await _dbContext.Nodes.AddAsync(node);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var node = await _dbContext
                        .Nodes
                        .FirstOrDefaultAsync(n => n.Id == id);

            if (node == null)
            {
                throw new Exception("Error");
            }

            _dbContext.Nodes.Remove(node);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Node> GetNodeWithChildren(Node node)
        {
            return await _dbContext
                .Nodes
                .Include(n => n.Children)
                .FirstOrDefaultAsync(n => n == node);
        }

        public async Task<Node> GetNodeById(int id)
        {
            return await _dbContext.Nodes.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task DeleteNode(Node node)
        {
            _dbContext.Nodes.RemoveRange(node);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Node> GetNodeByName(string name)
        {
            return await _dbContext.Nodes.FirstOrDefaultAsync(n => n.Name == name);
        }

        public async Task UpdateNode(Node node)
        {
            _dbContext.Nodes.Update(node);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Node> GetNodeWithChildren(int id)
        {
            return await _dbContext.Nodes.Include(n => n.Children).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<List<Node>> GetNodesOrderedById()
        {
            return await _dbContext.Nodes.OrderBy(n => n.Id).ToListAsync();
        }
    }
}
