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
        public List<Visites> FindAll()
        {
            return new HopitalDBEntities().Visites.ToList<Visites>();
        }

        public Visites FindById(int id)
        {
            var context = new HopitalDBEntities();
            var a = context.Visites.Find(id);
            return a;
        }

        public Visites Delete(int id)
        {
            var context = new HopitalDBEntities();
            var a = context.Visites.Find(id);
            context.Visites.Remove(a);
            context.SaveChanges();
            return a;
        }

        public Visites Create(Visites a)
        {
            var context = new HopitalDBEntities();
            context.Visites.Add(a);
            context.SaveChanges();
            return a;
        }

        public Visites Update(Visites p)
        {
            HopitalDBEntities context = new HopitalDBEntities();
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
            return p;
        }
    }
}




