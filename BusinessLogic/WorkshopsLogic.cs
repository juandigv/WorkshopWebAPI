using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueWebAPI.Database;

namespace TrueWebAPI.BusinessLogic
{
    public class WorkshopsLogic
    {
        WorkshopsTable wt = new WorkshopsTable();
        int idcount = 1;
        public List<Workshop> getAll(){
           
                return wt.getAll();
            

        }

        public void addWorkshop(string name)
        {
            if (name != null || name != "")
            {
                Workshop workshop = new Workshop();
                workshop.Id = idcount;
                workshop.Name = name;
                workshop.Status = "Scheduled";
                wt.addWorkshop(workshop);
                idcount++;
            }
        }

        public void putWorkshop(Workshop workshop)
        {
            if(workshop.Id != null || workshop.Name != null || workshop.Status != null || workshop.Status == "Scheduled" || workshop.Status == "Postponed" || workshop.Status == "Cancelled")
            {
                wt.updateWorkshop(workshop);
            }
        }

        public void deleteWorkshop(int id)
        {
            if(id != null)
            {
                wt.deleteWorkshop(id);
            }
        }

        public void postponeWorkshop(int id)
        {
            List<Workshop> works = getAll();
            var w = works.FirstOrDefault(o => id == o.Id);
            if (w != null)
            {
                w.Status = "Postponed";
                wt.updateWorkshop(w);
            }
        }

        public void cancellWorkshop(int id)
        {
            List<Workshop> works = getAll();
            var w = works.FirstOrDefault(o => id == o.Id);
            if (w != null)
            {
                w.Status = "Cancelled";
                wt.updateWorkshop(w);
            }
        }
    }
}
