using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tree.Application.NodeDto;
using Tree.Application.Services;
using Tree.Application.Tree;
using Tree.Domain.Entities;
using Tree.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tree.MVC.Controllers
{
    public class TreeController : Controller
    {
        private readonly ITreeService _treeService;
        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNodeDto tree)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { message = "Error" });
            }

            await _treeService.Create(tree);
            return RedirectToAction("Index"); //TODO: refactor
        }

        // [HttpGet("IsPossible")]
        public async Task<IActionResult> IsPossible(Node node, Node targetNode)
        {
            var isPossible = await _treeService.IsPossible(node, targetNode);

            return Ok(isPossible);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _treeService.DeleteNode(id);

            if (!isDeleted)
            {
                return RedirectToAction("Index", new { message = "Node not found" });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditNodeDto dto)
        {
            var isEdited = await _treeService.EditNode(dto);

            if (!isEdited)
            {
                return RedirectToAction("Index", new { message = "Invalid edit data" });
            }

            return RedirectToAction("Index");
        }
    }
}
