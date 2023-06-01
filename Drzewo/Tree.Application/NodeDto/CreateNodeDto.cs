using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Tree.Application.Tree
{
    public class CreateNodeDto
    {
        [Required(ErrorMessage = "Please, enter the name")]
        [StringLength(100)]
        public string Name { get; set; }
        public string? ParentNode { get; set; }

        public List<SelectListItem>? Parent { get; set; }
    }
}
