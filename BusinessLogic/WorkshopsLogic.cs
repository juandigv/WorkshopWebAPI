using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueWebAPI.Database;

namespace TrueWebAPI.BusinessLogic
{
    public class WorkshopsLogic : IWorkshopsLogic
    {

        private readonly IWorkshopsTable workshopsTable;

        public WorkshopsLogic(IWorkshopsTable workshopsTable)
        {
            this.workshopsTable = workshopsTable;
        }

        public List<Workshop> getAll()
        {
            return workshopsTable.getAll();
        }

        public void addWorkshop(string name)
        {
            if (name != null || name != "")
            {
                Workshop workshop = new Workshop();
                workshop.Id = generateId();
                workshop.Name = name;
                workshop.Status = "Scheduled";
                workshopsTable.addWorkshop(workshop);
            }
        }

        private int generateId()
        {
            List<Workshop> workshopsList = workshopsTable.getAll();
            if (workshopsList.Count > 0)
            {
                Workshop last = workshopsTable.getAll().Last<Workshop>();
                return last.Id + 1;
            }
            else
            {
                return 1;
            }

        }

        public void putWorkshop(Workshop workshop)
        {
            if (!(workshop.Id.Equals(null)) || workshop.Name != null || workshop.Status != null || workshop.Status == "Scheduled" || workshop.Status == "Postponed" || workshop.Status == "Cancelled")
            {
                workshopsTable.updateWorkshop(workshop);
            }
        }

        public void deleteWorkshop(int id)
        {
            if (!(id.Equals(null)))
            {
                workshopsTable.deleteWorkshop(id);
            }
        }

        public void postponeWorkshop(int id)
        {
            List<Workshop> works = getAll();
            var foundWorkshop = works.FirstOrDefault(o => id == o.Id);
            if (foundWorkshop != null)
            {
                foundWorkshop.Status = "Postponed";
                workshopsTable.updateWorkshop(foundWorkshop);
            }
        }

        public void cancelWorkshop(int id)
        {
            List<Workshop> works = getAll();
            var foundWorkshop = works.FirstOrDefault(o => id == o.Id);
            if (foundWorkshop != null)
            {
                foundWorkshop.Status = "Cancelled";
                workshopsTable.updateWorkshop(foundWorkshop);
            }
        }
    }
}
