using AprioritFoldersTask.Repositories;
using AprioritFoldersTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AprioritFoldersTask.Controllers
{
    public class FoldersController : AsyncController
    {

        private IFoldersService _foldersService;

        public FoldersController(IFoldersService foldersService)
        {
            this._foldersService = foldersService;
        }
        // GET: Folders
        public async Task<ActionResult> Index()
        {
            var rootFolder = await _foldersService.GetRootFolder();
            return View(rootFolder);
        }
    }
}