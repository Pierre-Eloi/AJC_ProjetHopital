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

        public string AddPatient(Patients patient)
        {
            //A valider avec le groupe

            bool alreadyInQueue = FileAttente.Any(p => p.Id == patient.Id);
            string Res = "";
            if (alreadyInQueue == false)
            {
                FileAttente.Enqueue(patient);
                Res = $"\nLe patient { patient.Nom} a été ajouté à la file d'attente";
                //envoyer une mise à jour dans le fichier txt
                string dateFormat = DateTime.Now.ToString("dd/MM/yyyy");
                string heureFormat = DateTime.Now.ToString("HH:mm:ss");
                using (StreamWriter sw = File.AppendText(@"C: \Users\damdi\OneDrive\Documents\ProjetHopital\Log\hopital.txt"))
                {
                    sw.WriteLine($"Patient : {patient.Nom} Id : {patient.Id} - Date et Heure d'arrivée à l'hopital: {dateFormat} {heureFormat}");
                }
            }
            else
            {
                //a valider dimanche
                Res = "Ce patient est déjà dans la file d'attente.";
            }
            return Res;
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
