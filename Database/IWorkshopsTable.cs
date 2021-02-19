using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrueWebAPI.Database
{
    public interface IWorkshopsTable
    {
        List<Workshop> getAll();
        void addWorkshop(Workshop wk);
        void updateWorkshop(Workshop wk);
        void deleteWorkshop(int id);

    }
}
