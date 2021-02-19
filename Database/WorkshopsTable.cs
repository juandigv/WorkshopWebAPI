using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using TrueWebAPI.Database;

namespace TrueWebAPI.Database
{
    public class WorkshopsTable: IWorkshopsTable
    {
        private List<Workshop> workshopList { get; set; }

        public WorkshopsTable()
        {
            workshopList = new List<Workshop>();
        }

        public List<Workshop> getAll()
        {
            return workshopList;
        }

        public void addWorkshop(Workshop wk)
        {
            workshopList.Add(wk);
        }

        public void updateWorkshop(Workshop wk)
        {
            var w = workshopList.FirstOrDefault(o => wk.Id == o.Id);
            if (w != null)
            {
                w.Name = wk.Name;
                w.Status = wk.Status;
            }
        }

        public void deleteWorkshop (int id)
        {
            var w = workshopList.FirstOrDefault(o => id == o.Id);
            if (w != null)
            {
                workshopList.Remove(w);
            }
        }
    }
}
