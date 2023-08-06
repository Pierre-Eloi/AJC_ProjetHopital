using ProjetHopital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetHopital
{
    class TestLucila
    {
        static void TestFindAll()
        {
            HopitalDBEntities context = new HopitalDBEntities();
            List<Patients> liste = context.Patients.ToList<Patients>();

            foreach (Patients a in liste)
                Console.WriteLine(a.Id + a.Nom + "  " + a.Prenom + "  " + a.Age + "  " + a.Telephone + "  " + a.Rue + "  " + a.CP + "  " + a.Ville);

        }

        static void TestCreate()
        {
            HopitalDBEntities context = new HopitalDBEntities();
            Patients a = new Patients
            {/* Id = 4,*/
                Nom = "DUPONT",
                Prenom = "laurent",
                Age = 34,
                Telephone = "069845",
                Rue = "5 rue de Rivoli",
                CP = 3300 ​,
                Ville = "Bordeaux"
            };
            context.Patients.Add(a);
            context.SaveChanges();

        }

        static void TestFindById()
        {
            int Id = 3;
            HopitalDBEntities context = new HopitalDBEntities();
            Patients a = context.Patients.Find(Id);
            Console.WriteLine(a.Id + "  " + a.Nom + "  " + a.Prenom + "  " + a.Age + "  " + a.Telephone + "  " + a.Rue + "  " + a.CP + "  " + a.Ville);



        }

        static void TestDelete()
        {
            int Id = 4;
            HopitalDBEntities context = new HopitalDBEntities();
            Patients a = context.Patients.Find(Id);
            context.Patients.Remove(a);
            context.SaveChanges();


        }

        static void TestUpdate()
        {
            int Id = 3;
            HopitalDBEntities context = new HopitalDBEntities();
            Patients a = context.Patients.Find(Id);
            a.Age = 38;
            context.SaveChanges();




        }


    }
}
