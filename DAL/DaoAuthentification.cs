using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHopital.DAL
{
    public class DaoAuthentification
    {
        public bool VerifierLogin(int Login, string Password)
        {
            try
            {
                HopitalDBEntities context = new HopitalDBEntities();
                Authentification x = context.Authentification.FirstOrDefault
                    (a => a.Login == Login && a.Password == Password);

                return x != null;
            }
            catch
            {
                return false;
            }
        }
        public List<Authentification> FindAll()
        {
            return new HopitalDBEntities().Authentification.ToList<Authentification>();
        }

        public Authentification Update(Authentification x)
        {
            HopitalDBEntities context = new HopitalDBEntities();
            context.Entry(x).State = EntityState.Modified;
            context.SaveChanges();
            return x;
        }
        public Authentification FindById(int id)
        {
            HopitalDBEntities context = new HopitalDBEntities();
            Authentification a = context.Authentification.Find(id);
            return a;
        }
        public Authentification Delete(int id)
        {
            HopitalDBEntities context = new HopitalDBEntities();
            Authentification x = context.Authentification.Find(id);
            context.Authentification.Remove(x);
            context.SaveChanges();
            return x;
        }

        public Authentification Create(Authentification x)
        {
            HopitalDBEntities context = new HopitalDBEntities();
            context.Authentification.Add(x);
            context.SaveChanges();

            return x;
        }

    }
}
