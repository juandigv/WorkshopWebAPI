using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrueWebAPI.BusinessLogic
{
    public interface IWorkshopsLogic
    {
        List<Workshop> getAll();
        void addWorkshop(string name);
        void putWorkshop(Workshop workshop);
        void deleteWorkshop(int id);
        void postponeWorkshop(int id);
        void cancelWorkshop(int id);
    }
}
