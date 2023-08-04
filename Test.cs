
using ProjetHopital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//mettre les using adéquats avant de commencer , mettre à niveau default
namespace ProjetHopital
{
    class Test
    {
        //mettre en commentaire les appels de méthode Anime pendant les tests
        static void Main(string[] args)
        {
            run();
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

        static void WelcomeClient(string nom)
        {
            Console.Clear();
            Console.WriteLine($"     Bonjour ,{nom}     \n");
        }

        static string GetUserInput(string prompt)
        {
            Console.WriteLine($"\nVeuillez entrer {prompt}");
            return Console.ReadLine();
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

        static T convertir<T>(string prompt)
        {
            bool valid = false;
            string userInput;
            T result = default;

            while (!valid)
            {
                userInput = GetUserInput(prompt);
                try
                {
                    result = (T)Convert.ChangeType(userInput, typeof(T));
                    valid = true;
                }
                catch
                {
                    PrintMessage("Entrée non valide, Veuillez réessayer", false);
                }
            }

            return result;
        }

        static void prompt()
        {
            convertir<int>("Votre Identifiant");
            convertir<string>("Votre Mot de Passe");

        }

        static Authentification login()
        {
            Authentification auth = new Authentification();
            DaoAuthentification daoAuth = new DaoAuthentification();
            bool identificationCorrecte = false;

            while (!identificationCorrecte)
            {
                int identifiant = convertir<int>("Votre Identifiant");
                string motDePasse = convertir<string>("Votre Mot de Passe");
                //loginProgress(); A décommenter après fin tests

                if (daoAuth.VerifierLogin(identifiant, motDePasse))
                {
                    PrintMessage("Authentification réussie ! Vous pouvez entrer.");
                    auth = daoAuth.FindById(identifiant);
                    identificationCorrecte = true;
                }
                else
                {
                    PrintMessage("Identifiant ou mot de passe incorrect.", false);
                    identificationCorrecte = false;
                }
            }

            return auth;
        }



        static void DisplayMedecin()
        {
            Console.WriteLine("--------Bienvenue dans l'Interface Medecin-------- ");
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
        static void ProcessMenuOption(Authentification A)
        {
            WelcomeClient(A.Nom);
            switch (A.Métier)
            {
                case 0:
                    DisplaySecretaire();
                    break;
                case 1:
                case 2:
                    DisplayMedecin();
                    break;
            }
        }

        static void Quitter()
        {
            Console.WriteLine("Merci d'avoir utilisé l'application HOPITAL ");
            Anime();
            Console.Clear();
        }

    }
}
