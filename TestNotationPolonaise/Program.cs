/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary> 
        /// donne le résultat d'une formule en notation polonaise
        /// </summary>
        /// <param name="formule">formule en notation polonaise</param>
        /// <returns>résultat</returns>
        static float Polonaise(String formule)
        {
            // découpage de la chaîne reçue en entrée dans un tableau de chaînes
            string[] tab = formule.Split(' ');
            // calcul de la taille du tableau obtenu
            int taille = tab.Length;
            // boucle pour faire le calcul
            try
            {
                for (int n = taille - 3; n >= 0; n--)
                {
                    if (tab[n] == "+" || tab[n] == "-" || tab[n] == "/" || tab[n] == "*")
                    {
                        switch(tab[n])
                        {
                            case "+":
                                tab[n] = (float.Parse(tab[n + 1]) + float.Parse(tab[n + 2])).ToString();
                                break;
                            case "-":
                                tab[n] = (float.Parse(tab[n + 1]) - float.Parse(tab[n + 2])).ToString();
                                break;
                            case "/":
                                tab[n] = (float.Parse(tab[n + 1]) / float.Parse(tab[n + 2])).ToString();
                                break;
                            case "*":
                                tab[n] = (float.Parse(tab[n + 1]) * float.Parse(tab[n + 2])).ToString();
                                break;
                        }
                        // décalage de la fin du vecteur
                        for (int i = n+1; i < taille - 2; i++)
                        {
                            tab[i] = tab[i + 2];
                            tab[i + 2] = "";
                        }
                    }
                }
                tab[1] = tab[2] = "";
                return float.Parse(tab[0]);
            }
            catch
            {
                return float.NaN;
            }            
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("Entrez une formule polonaise en séparant chaque partie par un espace = ");
                String laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat = " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
