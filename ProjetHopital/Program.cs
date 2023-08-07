using ProjetHopital.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetHopital
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Test()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"..\..\Logs\Test.txt");
                //Write a line of text
                sw.WriteLine("Hello World!!");
                //Write a second line of text
                sw.WriteLine("From the StreamWriter class");
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }


        static void Run()
        {
            var a = Login();
            ProcessMenuOption(a);
        }

        static Authentification Login()
        {
            var user = new Dictionary<string, string>();
            var a = new Authentification();

            Console.Clear();
            Console.Title = "APPLICATION HOPITAL";
            Console.WriteLine("\n----------Bienvenue à l'Hôpital----------\n");
            user["login"] = GetUserInput("votre Identifiant");
            user["password"] = GetUserInput("votre mot de passe");
            a = CheckLogin(user);
            return a;
        }

        static string GetUserInput(string prompt)
        {
            Console.WriteLine($"\nVeuillez entrer {prompt}");
            return Console.ReadLine();
        }

        static Authentification CheckLogin(Dictionary<string, string> user)
        {
            bool isSuccess = false;
            var a = new Authentification();
            do
            {
                try
                {
                    a = new DaoAuthentification().FindById(int.Parse(user["login"]));
                    loginProgress();

                    if (a != null && a.Password == user["password"])
                    {
                        PrintMessage("Authentification réussie ! Vous pouvez entrer.");
                        isSuccess = true;
                    }
                    else
                    {
                        PrintMessage("Identifiant ou mot de passe incorrect.", false);
                        user["login"] = GetUserInput("votre Identifiant");
                        user["password"] = GetUserInput("votre mot de passe");
                    }
                }
                catch (FormatException)
                {
                    PrintMessage("Format d'identifiant incorrect. Veuillez entrer un nombre entier.", false);
                    Console.Clear();
                    user["login"] = GetUserInput("votre Identifiant");
                    user["password"] = GetUserInput("votre mot de passe");
                }
            } while (isSuccess == false);

            return a;
        }

        static void ProcessMenuOption(Authentification a)
        {
            int response;
            bool success;
            Console.Clear();
            Console.WriteLine($"    Bonjour {a.Nom}\n");

            switch (a.Métier)
            {
                case 0:
                    var hopital = LoadBalancer.GetLoadBalancer();
                    DisplaySecretaire();
                    success = int.TryParse(Console.ReadLine(), out response);
                    if (success == false)
                        response = 0;
                    while (response != 5)
                    {
                        SecrApp(response, hopital);
                        Console.ReadLine();
                        DisplaySecretaire();
                        success = int.TryParse(Console.ReadLine(), out response);
                        if (success == false)
                            response = 0;
                    }
                    Console.WriteLine("\nMerci d'avoir utilisé l'application HOPITAL ");
                    Anime();
                    Run();
                    break;
                case 1:
                case 2:
                    var s = new Salle(a.Métier, a.Nom);
                    DisplayMedecin(a.Métier);
                    success = int.TryParse(Console.ReadLine(), out response);
                    if (success == false)
                        response = 0;
                    while (response != 5)
                    {
                        DocApp(response, s);
                        Console.ReadLine();
                        DisplayMedecin(a.Métier);
                        success = int.TryParse(Console.ReadLine(), out response);
                        if (success == false)
                            response = 0;
                    }
                    Console.WriteLine("\nMerci d'avoir utilisé l'application HOPITAL ");
                    Anime();
                    Run();
                    break;
            }
        }

        static void SecrApp(int value, LoadBalancer hopital)
        {

            switch (value)
            {
                case 1:
                    var id = int.Parse(GetUserInput("l'identifiant du patient"));
                    if (CheckPatient(id) == false)
                        CreatePatient();
                    var p = new DaoPatients().FindById(id);
                    //a voir dimanche
                    PrintMessage(hopital.AddPatient(p));
                    break;
                case 2:
                    Console.WriteLine($"\n{hopital.GetQueue()}");
                    break;
                case 3:
                    Console.WriteLine($"\n{hopital.NextPatient()}");
                    break;
                case 4:
                    id = int.Parse(GetUserInput("l'identifiant du patient"));
                    var vPatient = new DaoVisites().FindbyPatient(id);
                    Console.WriteLine($"\nListe des visites du patient {id}");
                    if (vPatient.Count() == 0)
                        Console.WriteLine($"Aucune visite du patient renseigné");
                    else
                    {
                        foreach (Visites v in vPatient)
                            Console.WriteLine($"Date: {v.Date} Médecin: {v.Médecin} Salle: {v.NumSalle}\n");
                    }
                    break;
                default:
                    PrintMessage("\nErreur de saisie, veuillez taper un chiffre entre 1 et 5", false);
                    break;
            }
        }

        static void DocApp(int value, Salle s)
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine($"\n{s.Notify()}");
                    break;
                case 2:
                    Console.WriteLine($"\n{s.Hopital.GetQueue()}");
                    break;
                case 3:
                    if (s.SaveVisites())
                        PrintMessage("\nLa sauvegarde a bien été effectuée ");
                    else
                        PrintMessage("\nUne erreur s'est produite," +
                            "la liste des visites n'a pas pu être enregistrée dans la base de données", false);
                    break;
                case 4:
                    var vDoc = new DaoVisites().FindbyDoc(s.DocName);
                    Console.WriteLine($"\nListe des visites de {s.DocName} - SALLE {s.NumSalle}\n" +
                        $"--------------------------------------");
                    if (vDoc.Count() == 0)
                        Console.WriteLine($"Aucune visite pour vous dans la base Docteur {s.DocName}");
                    else
                    {
                        foreach (Visites v in vDoc)
                            Console.WriteLine($"Patient: {v.IdPatient}  Date: {v.Date}\n");
                    }
                    break;
                default:
                    PrintMessage("\nErreur de saisie, veuillez tapper un chiffre entre 1 et 5", false);
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
            p.Nom = Console.ReadLine().ToUpper();
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

        static void DisplayMedecin(int? numSalle)
        {
            var message = "--------Bienvenue dans l'Interface Médecin--------\n" +
                $"Vous êtes dans la salle {numSalle}\n\n" +
                "Vous pouvez réaliser les actions suivantes :\n" +
                "1. Rendre disponible la salle ;\n" +
                "2. Afficher la file d'attente ;\n" +
                "3. Sauvegarder les visites dans la base de donnée ;\n" +
                "4. Afficher la liste de vos visites ;\n" +
                "5. Quitter ce menu et revenir à l'accueil.\n\n" +
                "Veuillez tapper le chiffre correspondant à l'action souhaitée.";
            Console.Clear();
            Console.WriteLine(message);
        }

        static void DisplaySecretaire()
        {
            var message = "-------Bienvenue dans l'Interface Secrétaire-------\n\n" +
                "Vous pouvez réaliser les actions suivantes :\n" +
                "1. Ajouter un patient à la file d'attente\n" +
                "2. Afficher la file d'attente\n" +
                "3. Afficher le premier patient de la file d'attente\n" +
                "4. Afficher toutes les visites d'un patient\n" +
                "5. Quitter ce menu et revenir à l'accueil.\n\n" +
                "Veuillez tapper le chiffre correspondant à l'action souhaitée.";
            Console.Clear();
            Console.WriteLine(message);
        }

        static void loginProgress()
        {
            Console.WriteLine("\nVérification de votre Identifiant et du mot de passe...");
            Anime();
        }

        static void Anime()
        {
            int timer = 9;
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                //entre chaque point une période de 200 millisecondes
                Thread.Sleep(200);
            }
            Console.Clear();
        }

        static void PrintMessage(string msg, bool succes = true)
        {
            if (succes)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
