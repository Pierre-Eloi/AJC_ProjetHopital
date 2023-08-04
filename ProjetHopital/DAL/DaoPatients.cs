using ProjetHopital.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Hopital.DAL
{
    public class DaoPatients

    {
        public List<Patients> FindAll()
        {
            return new HopitalDBEntities().Patients.ToList<Patients>();
        }

        public Patients FindByRef(int id)
        {
            var context = new HopitalDBEntities();
            var a = context.Patients.Find(id);
            return a;
        }

        public Patients Delete(int id)
        {
            var context = new HopitalDBEntities();
            var a = context.Patients.Find(id);
            context.Patients.Remove(a);
            context.SaveChanges();
            return a;
        }

        public Patients Create(Patients a)
        {
            var context = new HopitalDBEntities();
            context.Patients.Add(a);
            context.SaveChanges();
            return a;
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



