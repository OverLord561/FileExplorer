﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AprioritFoldersTask.ViewModels
{
    public class FolderViewModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}