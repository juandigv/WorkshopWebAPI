using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace TrueWebAPI.Database
{
    public class WorkshopsTable
    {
        public List<Workshop> workshopList = new List<Workshop>();

        public WorkshopsTable()
        {
            Workshop work = new Workshop();
            work.Id = 0;
            work.Name = "Prueba";
            work.Status = "Scheduled";

            workshopList.Add(work);
        }

        public List<Workshop> getAll()
        {
            Console.WriteLine("Reading");
            foreach (Workshop wk in workshopList)
            {
                Console.WriteLine("id: " + wk.Id + " name: " + wk.Name + " status: " + wk.Status);
            }
            return workshopList;
        }

        public void addWorkshop(Workshop wk)
        {
            workshopList.Add(wk);
            Console.WriteLine("id: " + wk.Id + " name: " + wk.Name + " status: " + wk.Status);
            Console.WriteLine("Reading2");
            foreach (Workshop wk2 in workshopList)
            {
                Console.WriteLine("id: " + wk2.Id + " name: " + wk2.Name + " status: " + wk2.Status);
            }
        }

        public void updateWorkshop(Workshop wk)
        {
            var w = workshopList.FirstOrDefault(o => wk.Id == o.Id);
            if (w != null)
            {
                w.Name = wk.Name;
                w.Status = wk.Status;
                Console.WriteLine("id: " + wk.Id + " name: " + wk.Name + " status: " + wk.Status);
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
