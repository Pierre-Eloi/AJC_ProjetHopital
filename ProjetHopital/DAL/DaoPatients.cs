using ProjetHopital.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHopital.DAL
{
    public class DaoPatients

    {
        public IEnumerable<Patients> FindAll()
        {
            return new HopitalDBEntities().Patients.ToList<Patients>();
        }

        public Patients FindById(int id)
        {
            var context = new HopitalDBEntities();
            var p = context.Patients.Find(id);
            return p;
        }

        public Patients Create(Patients p)
        {
            var context = new HopitalDBEntities();
            context.Patients.Add(p);
            context.SaveChanges();
            return p;
        }

        public Patients Delete(int id)
        {
            var context = new HopitalDBEntities();
            var p = context.Patients.Find(id);
            context.Patients.Remove(p);
            context.SaveChanges();
            return p;
        }        

        public Patients Update(Patients p)
        {
            HopitalDBEntities context = new HopitalDBEntities();
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
            return p;
        }
    }
}



