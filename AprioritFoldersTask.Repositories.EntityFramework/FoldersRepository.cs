using AprioritFoldersTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprioritFoldersTask.Repositories.EntityFramework
{
    public class FoldersRepository : Repository<Folders>, IFoldersRepository
    {
        public FoldersRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }

}
