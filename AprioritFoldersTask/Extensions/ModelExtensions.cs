using AprioritFoldersTask.Models;
using AprioritFoldersTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AprioritFoldersTask.Extensions
{
    public static class ModelExtensions
    {
        public static FolderViewModel ToViewModel(this Folders model)
        {
            return new FolderViewModel
            {
                Id = model.Id,
                ParentId = model.ParentId.Value,
                Name = model.Name,
                CreationDate = model.CreationDate.Value
            };
        }
    }
}