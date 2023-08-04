using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetHopital.DAL;

namespace ProjetHopital
{
    class TestPierre
    {
        static void TestFindAll()
        {
            var list = new DaoPatients().FindAll();
            var res = "";
            foreach (var p in list)
                res += $"{p.Id}\t{p.Nom}\t{p.Prenom}\t{p.Telephone}\n";
            Console.WriteLine(res);
        }

        static void TestSelectById()
        {
            int id = 1;
            var dao = new DaoPatients();
            var p = dao.FindById(id);

            if (p is object)
                Console.WriteLine($"{p.Id}\t{p.Nom}\t{p.Prenom}\t{p.Telephone}\n");
            else
                Console.WriteLine("Erreur de saisie : référence introuvable");
        }

        static void TestCreate()
        {
            var p = new Patients();
            p.Id = 4;
            p.Nom = "Toto";
            p.Prenom = "titi";
            new DaoPatients().Create(p);
        }

        static void TestUpdate()
        {
            var p = new Patients();
            p.Id = 4;
            p.Nom = "Toto2";
            p.Prenom = "titi2";
            new DaoPatients().Update(p);
        }

        static void TestDelete()
        {
            var id = 4;
            new DaoPatients().Delete(id);
        }
    }
}
