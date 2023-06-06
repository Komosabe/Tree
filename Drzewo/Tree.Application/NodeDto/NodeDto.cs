using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Domain.Entities;

namespace Tree.Application.NodeDto
{
    public class NodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NodeDto> Children { get; set; } = new List<NodeDto>();
    }
}
