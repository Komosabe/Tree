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
        public int? ToEditNodeId { get; set; } // selected node to edit id

        [StringLength(20, MinimumLength = 2)]
        public string NewName { get; set; } // new name
        public string ToEditNode { get; set; } // target node
        public List<Node>? Nodes { get; set; }

        public bool IsValid()
        {
            if (NewName is null && ToEditNode is null)
            {
                return false;
            }

            return true;
        }
    }
}
