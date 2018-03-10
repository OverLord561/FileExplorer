using AprioritFoldersTask.Services.Interfaces;
using AprioritFoldersTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprioritFoldersTask.Extensions;
using AprioritFoldersTask.Repositories;
using AprioritFoldersTask.Models;

namespace AprioritFoldersTask.Services
{

    public class FoldersService : IFoldersService
    {
        private IFoldersRepository _foldersRepository;

        public FoldersService(IFoldersRepository foldersRepository)
        {
            _foldersRepository = foldersRepository ?? throw new ArgumentNullException(nameof(foldersRepository));
        }
        public async Task<FolderViewModel> GetRootFolder()
        {
            return await _foldersRepository.SingleOrDefaultAsync<FolderViewModel>(x=>x.ParentId == null);
        }
    }

}
