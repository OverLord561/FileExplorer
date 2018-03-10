using AprioritFoldersTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AprioritFoldersTask.Controllers
{
    public class FoldersController : Controller
    {

        private IFoldersRepository _foldersRepository;

        public FoldersController(IFoldersRepository  foldersRepository)
        {
            this._foldersRepository = foldersRepository;
        }
        // GET: Folders
        public ActionResult Index()
        {
            var all = _foldersRepository.Get(x=>x.ParentId > 1).ToList();
            return View();
        }
    }
}