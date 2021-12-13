using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Morpion
{
    internal class Jeu
    {
        GrilleMorpion grilleMorpion = new GrilleMorpion(3, 3);
        GrillePuissance4 grillePuissance4 = new GrillePuissance4(4, 7);
        public void NouvellePartieMorpion()
        {
            int newGame = 1 ;

            Console.WriteLine("Début de la partie.");

            while (newGame == 1)
            {
                GrilleMorpion grilleMorpion = new GrilleMorpion(3, 3);

                while (grilleMorpion.Victoire() != true)
                {
                    grilleMorpion.AfficheGrille();
                    grilleMorpion.DeposeJeton();
                }

                Console.WriteLine("Voulez vous rejouer ? Entrez 1 pour oui et 2 pour non");
                //continu = Convert.ToString(Console.ReadLine());
                newGame = Convert.ToInt32(Console.ReadLine());

                while (newGame < 1 || newGame > 2)
                {
                    Console.WriteLine("Réponse incorrecte, voulez vous rejouer ? Entrez 1 pour oui et 2 pour non");
                    //continu = Convert.ToString(Console.ReadLine());
                    newGame = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void NouvellePartiePuissance4()
        {
            int newGame = 1;

            Console.WriteLine("Début de la partie.");

            grillePuissance4.AfficheNbLigneColonne();

            while (newGame == 1)
            {
                GrillePuissance4 grillePruissance4 = new GrillePuissance4(4, 7);

                while (grillePuissance4.Victoire() != true)
                {
                    grillePuissance4.AfficheGrille();
                    grillePuissance4.DeposeJeton();
                }

                Console.WriteLine("Voulez vous rejouer ? Entrez 1 pour oui et 2 pour non");
                //continu = Convert.ToString(Console.ReadLine());
                newGame = Convert.ToInt32(Console.ReadLine());

                while (newGame < 1 || newGame > 2)
                {
                    Console.WriteLine("Réponse incorrecte, voulez vous rejouer ? Entrez 1 pour oui et 2 pour non");
                    //continu = Convert.ToString(Console.ReadLine());
                    newGame = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void ChoixJeux()
        {
            int reponse;
            int lancerJeu = 1;

            while (lancerJeu == 1)
            {
                Console.WriteLine("Voulez vous au morpion ou au puissance 4 ? (entez 1 pour morpion et 2 pour puissance 4)");
                reponse = Convert.ToInt32(Console.ReadLine());

                if (reponse < 1 || reponse > 2)
                {
                    Console.WriteLine("Chiffre saisie faux, si vous voulez jouer au morpion entrez 1 et pour le puissance 4 entrez 2");
                    reponse = Convert.ToInt32(Console.ReadLine());
                }
                else if (reponse == 1)
                {
                    Jeu morpion = new Jeu();
                    morpion.NouvellePartieMorpion();
                }
                else if (reponse == 2)
                {
                    Jeu puissance4 = new Jeu();
                    puissance4.NouvellePartiePuissance4();
                }

                Console.WriteLine("Voulez vous jouer à un autre jeu ? (entrez 1 pour jouer à un autre jeu et entrez 2 pour quitter");
                lancerJeu = Convert.ToInt32(Console.ReadLine());

                if (lancerJeu < 1 || lancerJeu > 2)
                {
                    Console.WriteLine("Chiffre saisie faux, voulez vous jouer à un autre jeu ? (entrez 1 pour jouer à un autre jeu et entrez 2 pour quitter");
                    lancerJeu = Convert.ToInt32(Console.ReadLine());
                }
            }   
        }
    }
}
