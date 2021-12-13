using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Morpion
{
    internal class GrillePuissance4
    {

        private int[,] grillePuissance4;
        private int nbTourJ1 = 0;
        private int nbTourJ2 = 0;

        public GrillePuissance4(int ligne, int colonne)
        {
            grillePuissance4 = new int[ligne, colonne];
        }

        public bool CaseVide(int ligne, int colonne)
        {
            bool reponse = false;

            if (grillePuissance4[ligne, colonne] == 0)
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

            while (ligne < 1 || ligne > grillePuissance4.GetLength(0))
            {
                if (ligne < 1 || ligne > grillePuissance4.GetLength(0))
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

            while (colonne < 1 || colonne > grillePuissance4.GetLength(1))
            {
                if (colonne < 1 || colonne > grillePuissance4.GetLength(1))
                {
                    Console.WriteLine("Colonne fausse.");
                }

                Console.WriteLine("Veuillez saisir la colonne.");
                colonne = Convert.ToInt32(Console.ReadLine());
            }

            return colonne - 1;
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

            while (CaseVide(ligne, colonne) == false)
            {
                ligne = SaisirLigne();
                colonne = SaisirColonne();
            }

            grillePuissance4[ligne, colonne] = jeton;
        }

        public bool LigneComplete(int joueur)
        {
            bool reponse = false;
            int nbJetonOk = 0;

            for (int ligne = 0; ligne < grillePuissance4.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < grillePuissance4.GetLength(1); colonne++)
                {
                    if (grillePuissance4[ligne, colonne] == joueur)
                    {
                        nbJetonOk++;
                    }
                    else
                    {
                        nbJetonOk = 0;
                    }

                    if (nbJetonOk == 4)
                    {
                        reponse = true;
                        break;
                    }
                }

                if (nbJetonOk == 4)
                {
                    reponse = true;
                    break;
                }


            }

            return reponse;
        }

        public bool ColonneComplete(int joueur)
        {
            bool reponse = false;
            int nbJetonOk = 0;

            for (int colonne = 0; colonne < grillePuissance4.GetLength(1); colonne++)
            {
                for (int ligne = 0; ligne < grillePuissance4.GetLength(0); ligne++)
                {
                    if (grillePuissance4[ligne, colonne] == joueur)
                    {
                        nbJetonOk++;
                    }
                    else
                    {
                        nbJetonOk = 0;
                    }

                    if (nbJetonOk == 4)
                    {
                        reponse = true;
                        break;
                    }
                }

                if (nbJetonOk == 4)
                {
                    reponse = true;
                    break;
                }


            }

            return reponse;
        }

        public bool DiagonaleComplete(int joueur)
        {
            bool reponse = false;
            int nbJetonOk = 0;
            int nbLigne = grillePuissance4.GetLength(0);
            int nbColonne = grillePuissance4.GetLength(1);

            //Diagonale de gauche à droite
            for (int ligne = 0; ligne < nbLigne; ligne++)
            {
                for (int colonne = 0; colonne < nbColonne; colonne++)
                {
                    if (grillePuissance4[ligne, colonne] == joueur)
                    {
                        if (ligne + 1 < nbLigne && ligne + 2 < nbLigne && ligne + 3 < nbLigne && colonne + 1 < nbColonne && colonne + 2 < nbColonne && colonne + 3 < nbColonne)
                        {
                            if (grillePuissance4[ligne + 1, colonne + 1] == joueur && grillePuissance4[ligne + 2, colonne + 2] == joueur && grillePuissance4[ligne + 3, colonne + 3] == joueur)
                            {
                                nbJetonOk = 4;
                                reponse = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        nbJetonOk = 0;
                    }
                }

                if (nbJetonOk == 4)
                {
                    break;
                }
            }

            //Diagonale de droite à gauche
            if (reponse == false)
            {
                for (int ligne = 0; ligne < nbLigne; ligne++)
                {
                    for (int colonne = 0; colonne < nbColonne; colonne++)
                    {
                        if (grillePuissance4[ligne, colonne] == joueur)
                        {
                            if (ligne + 1 < nbLigne && ligne + 2 < nbLigne && ligne + 3 < nbLigne && colonne - 1 >= 0 && colonne - 2 >= 0 && colonne - 3 >= 0)
                            {
                                if (grillePuissance4[ligne + 1, colonne - 1] == joueur && grillePuissance4[ligne + 2, colonne - 2] == joueur && grillePuissance4[ligne + 3, colonne - 3] == joueur)
                                {
                                    nbJetonOk = 4;
                                    reponse = true;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            nbJetonOk = 0;
                        }
                    }

                    if (nbJetonOk == 4)
                    {
                        break;
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

            for (int ligne = 0; ligne < grillePuissance4.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < grillePuissance4.GetLength(1); colonne++)
                {
                    if (grillePuissance4[ligne, colonne] == 0)
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

            for (int i = 0; i < grillePuissance4.GetLength(0); i++)
            {
                for (int j = 0; j < grillePuissance4.GetLength(1); j++)
                {
                    ligne += "|";
                    ligne += Convert.ToString(grillePuissance4[i, j]);
                }
                Console.WriteLine(ligne + "|");
                ligne = null;
            }
        }
        public void AfficheNbLigneColonne()
        {
            int ligne = grillePuissance4.GetLength(0);
            int colonne = grillePuissance4.GetLength(1);

            Console.WriteLine("Nombre de ligne : " + ligne);
            Console.WriteLine("Nombre de colonne : " + colonne);
        }
    }

}
