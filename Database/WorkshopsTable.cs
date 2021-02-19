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

        public void addWorkshop(Workshop workshopToAdd)
        {
            workshopList.Add(workshopToAdd);
        }

        public void updateWorkshop(Workshop workshopToUpdate)
        {
            var foundWorkshop = workshopList.FirstOrDefault(o => workshopToUpdate.Id == o.Id);
            if (foundWorkshop != null)
            {
                foundWorkshop.Name = workshopToUpdate.Name;
                foundWorkshop.Status = workshopToUpdate.Status;
            }
        }

        public void deleteWorkshop (int id)
        {
            var foundWorkshop = workshopList.FirstOrDefault(o => id == o.Id);
            if (foundWorkshop != null)
            {
                workshopList.Remove(foundWorkshop);
            }
        }
    }
}
