using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueWebAPI.Database;

namespace TrueWebAPI.BusinessLogic
{
    public class WorkshopsLogic:IWorkshopsLogic
    {

        private readonly IWorkshopsTable workshopsTable;
        int idcount = 1;

        public WorkshopsLogic(IWorkshopsTable workshopsTable)
        {
            this.workshopsTable = workshopsTable;
        }

        public List<Workshop> getAll(){
                return workshopsTable.getAll();
        }

        public void addWorkshop(string name)
        {
            if (name != null || name != "")
            {
                Workshop workshop = new Workshop();
                workshop.Id = idcount;
                workshop.Name = name;
                workshop.Status = "Scheduled";
                workshopsTable.addWorkshop(workshop);
                idcount++;
            }
        }

        public void putWorkshop(Workshop workshop)
        {
            if(workshop.Id.Equals(null) || workshop.Name != null || workshop.Status != null || workshop.Status == "Scheduled" || workshop.Status == "Postponed" || workshop.Status == "Cancelled")
            {
                workshopsTable.updateWorkshop(workshop);
            }
        }

        public void deleteWorkshop(int id)
        {
            if(id.Equals(null))
            {
                workshopsTable.deleteWorkshop(id);
            }
        }

        public void postponeWorkshop(int id)
        {
            List<Workshop> works = getAll();
            var w = works.FirstOrDefault(o => id == o.Id);
            if (w != null)
            {
                w.Status = "Postponed";
                workshopsTable.updateWorkshop(w);
            }
        }

        public void cancellWorkshop(int id)
        {
            List<Workshop> works = getAll();
            var w = works.FirstOrDefault(o => id == o.Id);
            if (w != null)
            {
                w.Status = "Cancelled";
                workshopsTable.updateWorkshop(w);
            }
        }
    }
}
