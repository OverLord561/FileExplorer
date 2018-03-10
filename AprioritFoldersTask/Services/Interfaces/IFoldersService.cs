using AprioritFoldersTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprioritFoldersTask.Services.Interfaces
{
    public interface IFoldersService
    {
        Task<FolderViewModel> GetRootFolder();
    }
    
}
