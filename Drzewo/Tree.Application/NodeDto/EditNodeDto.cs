using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Tree.Domain.Entities;

namespace Tree.Application.NodeDto
{
    public class EditNodeDto
    {
        [Required(ErrorMessage ="Please, select node")]
        public int? ToEditNodeId { get; set; } // name to edit
        public string? Name { get; set; } // new name
        public string? ToEditNode { get; set; }
        public List<Node>? Nodes { get; set; }
    }
}
