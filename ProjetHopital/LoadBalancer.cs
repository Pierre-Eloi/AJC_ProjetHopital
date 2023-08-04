using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetHopital.DAL;

namespace ProjetHopital
{
    public sealed class LoadBalancer
    {
        private static readonly LoadBalancer instance = new LoadBalancer();

        public Queue<Patients> FileAttente { get; set; }

        //----------Constructor----------
        private LoadBalancer()
        {
            this.FileAttente = new Queue<Patients>();
        }

        //----------Methods----------
        public static LoadBalancer GetLoadBalancer()
        {
            return instance;
        }

        public Patients Update()
        {
            Patients patient = null;
            if (FileAttente.Count > 0)
                patient = FileAttente.Dequeue();
            return patient;
        }

        public void AddPatient(Patients patient)
        {
            FileAttente.Enqueue(patient);
        }

        public string GetInfo(Patients p)
        {
            var res = "";
            if (p is object)
            {
                res += $"Nom : {p.Nom}\n" +
                   $"Prénom : {p.Prenom}\n" +
                   $"Age : {p.Age} ans\n" +
                   $"------------------------------\n";
            }               
            return res;
        }
        public string NextPatient()
        {
            return GetInfo(FileAttente.Peek());
        }

        public string GetQueue()
        {
            var res = $"Nombre de patients : {FileAttente.Count}\n" +
                $"------------------------------\n";
            foreach (Patients p in FileAttente)
                res += GetInfo(p);
            return res;
        }
    }
}
