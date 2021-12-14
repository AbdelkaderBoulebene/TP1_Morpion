using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Morpion
{
    internal class Jeu
    {
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

                grilleMorpion.AfficheGrille();

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


            while (newGame == 1)
            {
                GrillePuissance4 grillePuissance4 = new GrillePuissance4(4, 7);

                grillePuissance4.AfficheNbLigneColonne();

                while (grillePuissance4.Victoire() != true)
                {
                    grillePuissance4.AfficheGrille();
                    grillePuissance4.DeposeJeton();
                }

                grillePuissance4.AfficheGrille();

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

        public void NouvellePartiePerso()
        {
            int newGame = 1;
            int nbLigne;
            int nbColonne;

            Console.WriteLine("Entrez le nombre de ligne de la grille");
            nbLigne = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Entrez le nombre de colonne de la grille");
            nbColonne = Convert.ToInt32(Console.ReadLine());

            while (nbLigne < 4 || nbColonne < 4)
            {
                Console.WriteLine("Le nombre de ligne et de colonne doit être au minimum de 4. Entrez le nombre de ligne de la grille");
                Console.WriteLine("Entrez le nombre de ligne  de la grille");
                nbLigne = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Entrez le nombre de colonne de la grille");
                nbColonne = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Début de la partie.");

            while (newGame == 1)
            {
                GrillePuissance4 grillePuissance4 = new GrillePuissance4(nbLigne, nbColonne);

                grillePuissance4.AfficheNbLigneColonne();

                while (grillePuissance4.Victoire() != true)
                {
                    grillePuissance4.AfficheGrille();
                    grillePuissance4.DeposeJeton();
                }

                grillePuissance4.AfficheGrille();

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
                Console.WriteLine("Voulez vous jouez au morpion, au puissance 4 ou faire une partie de puissance 4 avec une grille personnalisé ? (entez 1 pour morpion, 2 pour puissance 4 et 3 pour la partie personnalisé.)");
                reponse = Convert.ToInt32(Console.ReadLine());

                if (reponse < 1 || reponse > 3)
                {
                    Console.WriteLine("Chiffre saisie faux, si vous voulez jouer au morpion entrez 1, 2 pour le puissance 4 et 3 pour la partie parsonnalisé.");
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
                else if (reponse == 3)
                {
                    Jeu puissance4 = new Jeu();
                    puissance4.NouvellePartiePerso();
                }

                Console.WriteLine("Voulez vous jouer à un autre jeu ? (entrez 1 pour jouer à un autre jeu et 2 pour quitter).");
                lancerJeu = Convert.ToInt32(Console.ReadLine());

                if (lancerJeu < 1 || lancerJeu > 2)
                {
                    Console.WriteLine("Chiffre saisie faux, voulez vous jouer à un autre jeu ? (entrez 1 pour jouer à un autre jeu et 2 pour quitter).");
                    lancerJeu = Convert.ToInt32(Console.ReadLine());
                }
            }   
        }
    }
}
