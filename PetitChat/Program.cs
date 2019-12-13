using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace PetitChat
{
    class Program
    {
        /// <summary>
        /// Point d'entrée dans le programme "Petit Chat : Devinette :
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            PetitChat();
        }
        /// <summary>
        /// Petit Chat qui danse :
        /// Lance les fonctions : Devinette et Relance. Choix Mode et TentativesMax
        /// Devinette : Boucle principale à la recherche du bon nombre.
        /// Relance : "Voulez-vous relancer une partie ?".
        /// Choix du Mode : Niveau de difficulté.
        /// TentativesMax : Combien de tentatives maximum vous avez ?
        /// </summary>
        static void PetitChat()
        {
            bool choixValide = false;
            int i = 0;
            while (i != 4)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(@"            /\_/\");
                Console.WriteLine(@"           ( o.o )");
                Console.WriteLine(@"            > ^ <");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine(@"        /\_/\");
                Console.WriteLine(@"       ( o.o )");
                Console.WriteLine(@"        > ^ <");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine(@"            /\_/\");
                Console.WriteLine(@"           ( o.o )");
                Console.WriteLine(@"            > ^ <");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine(@"                /\_/\");
                Console.WriteLine(@"               ( o.o )");
                Console.WriteLine(@"                > ^ <");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine(@"            /\_/\");
                Console.WriteLine(@"           ( o.o )");
                Console.WriteLine(@"            > ^ <");
                Thread.Sleep(200);
                i++;
            }
            int aMaxValue = 0;
            while (choixValide == false)
            {
                aMaxValue = ChoixMode();
                if (aMaxValue == 0)
                {
                    Console.WriteLine("Non... Tu ne mérites même pas d'être un félin.");
                    choixValide = false;
                }
                else
                {
                    Console.WriteLine("Ha ! Tu es joueur...");
                    choixValide = true;
                }
            }
            Devinette(aMaxValue);
            Relance();
        }
        /// <summary>
        /// Devinette : Deux paramètres : pMaxValue / pTentativeMax.
        /// pMaxValue : RETURN de aMaxValue de la fonction ChoixMode().
        /// pTentativeMax : RETURN de aMaxValue de la fonction TentativeMaxValue().
        /// ... Quand tu te rends compte que ton nommage des variables est parfaite ! ;-)...
        /// </summary>
        /// <param name="pMaxValue"></param>
        /// <param name="pTentativeMax"></param>
        static void Devinette(int pMaxValue)
        {
            // Initiatilasation du jeu : Question et Création du random.
            int MaxValue = pMaxValue;
            int xTentatives;
            int aTentativeMax;
            if (MaxValue == 50)
            {
                aTentativeMax = 9;
                xTentatives = 10;
            }
            else if (MaxValue == 100)
            {
                aTentativeMax = 4;
                xTentatives = 5;
            }
            else
            {
                aTentativeMax = 2;
                xTentatives = 3;
            }
            Console.WriteLine("Le petit chat demande : Devine un nombre entre 1 et " + MaxValue + ".");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tu as " + xTentatives + " tentatives pour me prouver que tu mérites d'être un félin.");
            Random rn = new Random();
            int MonChiffre = rn.Next(1, MaxValue);
            int tentative = 0;
            bool relanceChat = false;
            bool relanceChoix = false;
            bool trouve = false;
            Console.WriteLine("Entrez un chiffre : ");
            // Boucle principale :
            // Entrée monTest : comparaison :
            // Nombre de tentatives :
            while (trouve == false)
            {
                string monTest = Console.ReadLine();
                int.TryParse(monTest, out int monTestInt);
                if (monTestInt == MonChiffre)
                {
                    tentative++;
                    Console.WriteLine("Tu as réussi : en " + tentative + " tentative(s)");
                    Thread.Sleep(3000);
                    trouve = true;
                }
                else if (monTestInt < MonChiffre && tentative < aTentativeMax)
                {
                    Controle(monTestInt, pMaxValue);
                    Console.Write("Perdu ! Le chiffre à trouver est plus ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("grand...");
                    Console.ForegroundColor = ConsoleColor.White;
                    tentative++;
                }
                else if (monTestInt > MonChiffre && tentative < aTentativeMax)
                {
                    Controle(monTestInt, pMaxValue);
                    Console.Write("Perdu ! Le chiffre à trouver est plus ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("petit...");
                    Console.ForegroundColor = ConsoleColor.White;
                    tentative++;
                }
                else if (monTestInt < MonChiffre && tentative > aTentativeMax)
                {
                    Controle(monTestInt, pMaxValue);
                    Console.Write("Perdu ! Le chiffre à trouver est plus ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("grand...");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("GNAC ! GNAC ! Tu as perdu tu as dépassé ton nombre de tentative !");
                    Console.WriteLine("Je ne te donne pas la solution, tente de nouveau !");
                    Console.ForegroundColor = ConsoleColor.White;
                    tentative++;
                }
                else if (monTestInt > MonChiffre && tentative > aTentativeMax)
                {
                    Controle(monTestInt, pMaxValue);
                    Console.Write("Perdu ! Le chiffre à trouver est plus ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("petit...");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("GNAC ! GNAC ! Tu as perdu tu as dépassé ton nombre de tentative !");
                    Console.WriteLine("Je ne te donne pas la solution, tente de nouveau !");
                    Console.ForegroundColor = ConsoleColor.White;
                    tentative++;
                }
                else
                {
                    Controle(monTestInt, pMaxValue);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("TU AS PERDU ! Tu es arrivé à ton nombre maximum de tentatives...");
                    Console.WriteLine("Je ne te donne pas la solution, tente de nouveau !");
                    Console.ForegroundColor = ConsoleColor.White;
                    tentative++;
                }
            }
            Console.WriteLine("Voulez-vous relancer une partie ?");
            Console.WriteLine("[1] = *Oui* / [2] = *Non*");
            string pChoixRelance = Relance();
            if (pChoixRelance == "1")
            {
                relanceChat = true;
            }
            else if (pChoixRelance == "2")
            {
                Console.WriteLine("Aurevoir ! Appuyez sur une touche pour Fermer.");
                relanceChat = false;
            }
            else
            {
                Console.WriteLine("... Ne jamais faire confiance à l'humanoïde !");
                relanceChoix = true;
            }
            if (relanceChoix == true)
            {
                Relance();
            }
            else if (relanceChat == true)
            {
                PetitChat();
            }
            else
            {
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Relancer le programme après une victoire :
        /// </summary>
        static string Relance()
        {
            string monChoixRelance = Console.ReadLine();
            string ChoixRelance;
            if (monChoixRelance == "1")
            {
                ChoixRelance = monChoixRelance;
            }
            else if (monChoixRelance == "2")
            {
                ChoixRelance = monChoixRelance;
            }
            else
            {
                ChoixRelance = monChoixRelance;
            }
            return ChoixRelance;
        }
        /// <summary>
        /// Controle de l'entrée utilisateur :
        /// </summary>
        /// <param name="paraMonTestInt"></param>
        /// <param name="aMaxValue"></param>
        static void Controle(int paraMonTestInt, int aMaxValue)
        {
            if (paraMonTestInt > aMaxValue)
            {
                Console.WriteLine("Sans déconner ? Qu'est ce que tu as pas compris ?");
            }
            else if (paraMonTestInt == 0)
            {
                Console.WriteLine("Nooooooooon !");
            }
            else
            {
                Console.WriteLine("Au moins tu as compris les règles du jeu : Tu as donné un chiffre valide.");
            }
        }
        /// <summary>
        /// Propose trois niveaux de difficulté :
        /// </summary>
        /// <returns></returns>
        static int ChoixMode()
        {
            int maxValue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Je suis *Petit Chat* joue avec moi et devine mon chiffre mystère :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Es-tu un chaton, un vrai chat, un gros matou ?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[1] = *Chaton* / [2] = *Chat*, [3] = *Gros Matou.");
            string monChoixMode = Console.ReadLine();
            if (monChoixMode == "1")
            {
                maxValue = 50;
            }
            else if (monChoixMode == "2")
            {
                maxValue = 100;
            }
            else if (monChoixMode == "3")
            {
                maxValue = 200;
            }
            else
            {
                maxValue = 0;
            }
            return maxValue;
        }
    }
}