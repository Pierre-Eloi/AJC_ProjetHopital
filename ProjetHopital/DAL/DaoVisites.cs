using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetHopital.DAL
{
    public class DaoVisites
    {
        public IEnumerable<Visites> FindbyPatient(int id)
        {
            var context = new HopitalDBEntities();
            return context.Visites.Where(v => v.IdPatient == id);
        }

        public IEnumerable<Visites> FindbyDoc(string name)
        {
            var context = new HopitalDBEntities();
            return context.Visites.Where(v => v.Médecin == name);
        }
        public IEnumerable<Visites> FindAll()
        {
            return new HopitalDBEntities().Visites.ToList<Visites>();
        }

        public Visites FindById(int id)
        {
            var context = new HopitalDBEntities();
            var v = context.Visites.Find(id);
            return v;
        }

        public Visites Delete(int id)
        {
            var context = new HopitalDBEntities();
            var v = context.Visites.Find(id);
            context.Visites.Remove(v);
            context.SaveChanges();
            return v;
        }

        public Visites Create(Visites v)
        {
            var context = new HopitalDBEntities();
            context.Visites.Add(v);
            context.SaveChanges();
            return v;
        }

        public Visites Update(Visites v)
        {
            HopitalDBEntities context = new HopitalDBEntities();
            context.Entry(v).State = EntityState.Modified;
            context.SaveChanges();
            return v;
        }
    }
}




