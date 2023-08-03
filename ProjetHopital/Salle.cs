using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetHopital.DAL;

namespace ProjetHopital
{
    public class Salle
    {
        public List<Visites> ListeVisites { get; set; }
        public LoadBalancer Hopital { get; set; }
        public int NumSalle { get; set; }
        public string DocName { get; set; }

        //----------Constructors----------
        public Salle()
        {
            this.Hopital = LoadBalancer.GetLoadBalancer();
            this.ListeVisites = new List<Visites>();
        }
        
        public Salle(int numSalle, string docName) : this()
        {            
            this.NumSalle = numSalle;
            this.DocName = docName;
        }

        //----------Methods----------
        public void Notify()
        {
            Patients patient = Hopital.Update();
            AddVisitor(patient.Id);
        }

        public void AddVisitor(int id)
        {
            var visitor = new Visites();
            visitor.IdPatient = id;
            visitor.Date = DateTime.Now ;
            visitor.NumSalle = this.NumSalle;
            visitor.Médecin = this.DocName;
            visitor.Tarif = 23;

            if (ListeVisites.Count == 10)
            {
                this.SaveVisites();
                ListeVisites = new List<Visites>();
            }
            ListeVisites.Add(visitor);
        }

        public void SaveVisites()
        {
            //var dao = new DAOVisites();
            if (ListeVisites.Count > 0)
            {
                foreach (Visites v in ListeVisites)
                {
                    //dao.insert(v)
                }
            }            
        }
    }
}
