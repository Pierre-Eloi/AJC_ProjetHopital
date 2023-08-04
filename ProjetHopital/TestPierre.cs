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
        static void SecrApp(int value)
        {
            var hopital = LoadBalancer.GetLoadBalancer();
            switch (value)
            {
                case 1:
                    Console.WriteLine("Entrez l'identifiant du patient");
                    var id = int.Parse(Console.ReadLine());
                    if (CheckPatient(id) == false)
                        CreatePatient();
                    hopital.AddPatient(new DaoPatients().FindById(id));
                    break;
                case 2:
                    hopital.GetQueue();
                    break;
                case 3:
                    hopital.NextPatient();
                    break;
                case 4:
                    break;
                default:
                    Test.Quitter();
                    break;
            }
        }
        static void DocApp(int value)
        {
            var hopital = LoadBalancer.GetLoadBalancer();
            Salle s =new Salle();
            switch (value)
            {
                case 1:
                    s.Notify();
                    break;
                case 2:
                    hopital.GetQueue();
                    break;
                case 3:
                    if(SaveVisites())
                    {
                        Console.WriteLine("La sauvegarde a bien été effectuée ");
                    }
                    else
                    {
                        Console.WriteLine("Une erreur s'est produite");
                    }
                    break;
                case 4:
                    Console.WriteLine($"\nListe des visites de {s.DocName} - SALLE {s.NumSalle}");
                    if (Liste.Count == 0)
                    {
                        Console.WriteLine($"Aucune visite pour vous dans la base docteur {s.DocName}");
                    }
                    else
                    {
                        foreach (Visite item in s.ListeVisites)
                        {
                            Console.WriteLine($"Patient: {item.IdPatient}  Date: {item.Date}  Tarif: {item.Tarif} ");
                        }
                    }
                    break;
                default:
                    Test.Quitter();
                    break;
            }
        }

        static bool CheckPatient(int id)
        {
            var isSuccess = false;
            var p = new DaoPatients().FindById(id);
            if (p is object)
            {
                isSuccess = true;                
            }               
            return isSuccess;
        }

        static void CreatePatient()
        {
            var p = new Patients();

            Console.WriteLine("Le patient renseigné n'est pas présent dans la base de donnée\n" +
                "veuillez entrer les informations suivantes :");
            Console.WriteLine("l'id :");
            p.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Le nom :");
            p.Nom = Console.ReadLine();
            Console.WriteLine("Le prénom :");
            p.Prenom = Console.ReadLine();
            Console.WriteLine("L'âge :");
            p.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Le numéro de téléphone :");
            p.Telephone = Console.ReadLine();
            Console.WriteLine("Le numéro et nom de rue :");
            p.Rue = Console.ReadLine();
            Console.WriteLine("Le code postal :");
            p.CP = int.Parse(Console.ReadLine());
            Console.WriteLine("La ville :");
            p.Ville = Console.ReadLine();

            new DaoPatients().Create(p);
        }

        static void run()
        {
            //ceci est un test en attendant 
            Welcome();
            ProcessMenuOption(login());
            //Quitter();
        }

        static void Welcome()
        {
            Console.Clear();
            Console.Title = "APPLICATION HOPITAL";
            //Message de bienvenue
            Console.WriteLine("\n----------Bienvenu à l'Hôpital----------");
        }

        static void ProcessMenuOption(Authentification A)
        {
            Console.Clear();
            Console.WriteLine($"    Bonjour {A.Nom}\n");
            switch (A.Métier)
            {
                case 0:
                    DisplaySecretaire();
                    break;
                case 1:
                case 2:
                    DisplayMedecin(A.Métier);
                    break;
            }
        }

        static void DisplayMedecin(int? numSalle)
        {
            Console.WriteLine("--------Bienvenue dans l'Interface Medecin-------- " +
                $"Vous êtes dans la salle {numSalle}");
            Console.WriteLine(":                                                 :");
            Console.WriteLine("1. Afficher l'état de la file d'attente           :");
            Console.WriteLine("2. Sauvegarder dans la Base, la liste des visites :");
            Console.WriteLine("3. Rendre la salle disponible                     :");
            Console.WriteLine("4. Afficher la liste de ses visites en base       :");
            Console.WriteLine("5. Afficher toutes les visites des deux salles    :");
            Console.WriteLine("6. Sortir de ce Menu et revenir au menu principal :");
        }
        static void DisplaySecretaire()
        {
            Console.WriteLine("-------Bienvenue dans l'Interface Secretaire------- ");
            Console.WriteLine(":                                                  :");
            Console.WriteLine("1. Afficher l'état de la File d'attente            :");
            Console.WriteLine("2. Rajouter un patient                             :");
            Console.WriteLine("3. Afficher le prochain patient de la File         :");
            Console.WriteLine("4. Afficher les visites d'un patient               :");
            Console.WriteLine("5. Afficher le fichier txt                         :");
            Console.WriteLine("6. Sortir de ce Menu et revenir au menu principal  :\n");

        }


    }
}
