using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Morpion
{
    public class GrilleMorpion
    {
        private int[,] grilleMorpion;
        private int nbTourJ1 = 0;
        private int nbTourJ2 = 0;
        public GrilleMorpion(int ligne,int colonne)
        {
            grilleMorpion = new int[ligne, colonne];
        }


        public bool CaseVide(int ligne, int colonne)
        {
            bool reponse = false;

            if (grilleMorpion[ligne,colonne] == 0)
            {
                reponse = true;
            }
            else
            {
                Console.WriteLine("Case non vide.");
            }

            return reponse;
        }

        public int SaisirLigne()
        {
            int ligne;

            Console.WriteLine("Veuillez saisir la ligne.");
            ligne = Convert.ToInt32(Console.ReadLine());

            while (ligne < 1 || ligne > grilleMorpion.GetLength(0))
            {
                if (ligne < 1 || ligne > grilleMorpion.GetLength(0))
                {
                    Console.WriteLine("Ligne fausse.");
                }
                
                Console.WriteLine("Veuillez saisir la ligne.");
                ligne = Convert.ToInt32(Console.ReadLine());
            }

            return ligne - 1;
        }
        public int SaisirColonne()
        {
            int colonne;

            Console.WriteLine("Veuillez saisir la colonne.");
            colonne = Convert.ToInt32(Console.ReadLine());

            while (colonne < 1 || colonne > grilleMorpion.GetLength(1))
            {
                if (colonne < 1 || colonne > grilleMorpion.GetLength(1))
                {
                    Console.WriteLine("Colonne fausse.");
                }

                Console.WriteLine("Veuillez saisir la colonne.");
                colonne = Convert.ToInt32(Console.ReadLine());
            }

            return colonne - 1;
        }

        public int SaisirDiagonale()
        {
            int diagonale;

            Console.WriteLine("Veuillez saisir la diagonale (1 pour la diagonale d'en haut à gauche et 2 pour la diagonale d'en haut à droite).");
            diagonale = Convert.ToInt32(Console.ReadLine());

            while (diagonale < 1 || diagonale > 2)
            {
                if (diagonale < 1 || diagonale > 2)
                {
                    Console.WriteLine("Diagonale fausse.");
                }

                Console.WriteLine("Veuillez saisir la diagonale (1 pour la diagonale d'en haut à gauche et 2 pour la diagonale d'en haut à droite).");
                diagonale = Convert.ToInt32(Console.ReadLine());
            }

            return diagonale;
        }

        public void DeposeJeton()
        {
            int ligne;
            int colonne;
            int jeton;

            if (nbTourJ1 <= nbTourJ2)
            {
                jeton = 1;
                nbTourJ1++;
            }
            else
            {
                jeton = 2;
                nbTourJ2++;
            }
            
            Console.WriteLine("Tour du joueur " + jeton);

            ligne = SaisirLigne();
            colonne = SaisirColonne();

            while (CaseVide(ligne,colonne) == false)
            {
                ligne = SaisirLigne();
                colonne = SaisirColonne();
            }

            

             grilleMorpion[ligne,colonne] = jeton;
        }

        public bool LigneComplete(int joueur)
        {
            bool reponse = false;

            for (int ligne = 0; ligne < grilleMorpion.GetLength(0); ligne++)
            {
                for (int i = 0; i < grilleMorpion.GetLength(1); i++)
                {
                    if (grilleMorpion[ligne, i] == joueur)
                    {
                        reponse = true;
                    }
                    else
                    {
                        reponse = false;
                        break;
                    }
                }

                if (reponse == true)
                {
                    break;
                }
            }

            return reponse;
        }

        public bool ColonneComplete(int joueur)
        {
            bool reponse = false;

            for (int colonne = 0; colonne < grilleMorpion.GetLength(1); colonne++)
            {
                for (int i = 0; i < grilleMorpion.GetLength(0); i++)
                {
                    if (grilleMorpion[i, colonne] == joueur)
                    {
                        reponse = true;
                    }
                    else
                    {
                        reponse = false;
                        break;
                    }
                }

                if (reponse == true)
                {
                    break;
                }
            }

            return reponse;
        }

        public bool DiagonaleComplete(int joueur)
        {
            bool reponse = false;
            int diagonale;
            int colonne = 2;

            for (diagonale = 1; diagonale <= 2; diagonale++)
            {
                if (diagonale == 1)
                {
                    for (int i = 0; i < grilleMorpion.GetLength(0); i++)
                    {
                        if (grilleMorpion[i, i] == joueur)
                        {
                            reponse = true;

                        }
                        else
                        {
                            reponse = false;
                            break;
                        }

                    }

                    if (reponse == true)
                    {
                        break;
                    }
                }

                if (diagonale == 2)
                {
                    for (int ligne = 0; ligne <= 2; ligne++)
                    {

                        if (grilleMorpion[ligne, colonne] == joueur)
                        {
                            reponse = true;

                        }
                        else
                        {
                            reponse = false;
                            break;
                        }
                        colonne--;
                    }
                }
            }
            
            return reponse;
        }

        public int SaisirJoueur()
        {
            int joueur;

            Console.WriteLine("Veuillez saisir un joueur.");
            joueur = Convert.ToInt32(Console.ReadLine());

            while (joueur < 0 || joueur > 2)
            {
                if (joueur < 0 || joueur > 2)
                {
                    Console.WriteLine("Joueur faux.");
                }

                Console.WriteLine("Veuillez saisir la colonne.");
                joueur = Convert.ToInt32(Console.ReadLine());
            }

            return joueur;
        }

        public bool Victoire()
        {
            int joueur;
            bool fin = false;

            for (joueur = 1; joueur <= 2; joueur++)
            {
                if (LigneComplete(joueur) == true || ColonneComplete(joueur) == true || DiagonaleComplete(joueur) == true)
                {
                    Console.WriteLine("Le joueur " + joueur + " a gagné !");
                    if (LigneComplete(joueur) == true)
                    {
                        Console.WriteLine("Victoire par ligne !");
                        fin = true;
                    }
                    else if (ColonneComplete(joueur) == true)
                    {
                        Console.WriteLine("Victoire par Colonne !");
                        fin = true;
                    }
                    else if (DiagonaleComplete(joueur) == true)
                    {
                        Console.WriteLine("Victoire par Diagonale !");
                        fin = true;
                    }
                    break;
                }
                else if (GrillePleinne() == true)
                {
                    Console.WriteLine("Égalité !");
                    fin = true;
                    break;
                }
            }

            return fin;
        }

        public bool GrillePleinne()
        {
            bool reponse = true;

            for (int ligne = 0; ligne < grilleMorpion.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < grilleMorpion.GetLength(1); colonne++)
                {
                    if (grilleMorpion[ligne,colonne] == 0)
                    {
                        reponse = false;
                        break;
                    }
                    if (reponse == false)
                    {
                        break;
                    }
                }
            }

            return reponse;
        }
        public void AfficheGrille()
        {
            string ligne = null;

            for (int i = 0; i < grilleMorpion.GetLength(0); i++)
            {
                for (int j = 0; j < grilleMorpion.GetLength(1); j++)
                {
                    ligne += "|";
                    ligne += Convert.ToString(grilleMorpion[i,j]);
                }
                Console.WriteLine(ligne + "|");
                ligne = null;
            }
        }

    }
}
