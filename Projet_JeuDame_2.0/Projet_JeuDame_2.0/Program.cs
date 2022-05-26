using System;

namespace Projet_JeuDame_2._0
{
    class Program
    {

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //fonction qui permet de créer la matrice en parcourant chaque case du tableau pour ajouter un "0"
        static void ConstruireMatrice(ref int[,] Tab_pion)
        {
            int nbrLigne = Tab_pion.GetLength(0);
            int nbrColonne = Tab_pion.GetLength(1);
            for (int i = 0; i < nbrLigne; i++)
            {
                for (int j = 0; j < nbrColonne; j++)
                {
                    Tab_pion[i, j] = 0;
                }
            }
        }

        //fonction qui permet de parcourir chaque case du tableau afin de les afficher et pouvoir ressortir tout le tableau
        static void AfficherMatrice(int[,] Tab_Pion)
        {
            int nbrLigne = Tab_Pion.GetLength(0);
            int nbrColonne = Tab_Pion.GetLength(1);

            for (int i = 0; i < nbrLigne; i++)
            {
                for (int j = 0; j < nbrColonne; j++)
                {
                    Console.Write(" " + Tab_Pion[i, j]);
                }
                Console.WriteLine();
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //fonction qui permet de placer les pions blanc sur le plateau de jeu
        static void PionNoir(ref int[,] Tab_Pion)
        {
            //pour les ligne de 0 => 3
            for (int i = 0; i < 4; i++)
            {
                int StartValue;
                //modulo= paire ou impaire
                if (i % 2 == 0)
                {
                    StartValue = 0;
                }

                else
                {
                    StartValue = 1;
                }

                for (int j = StartValue; j < 10; j = j + 2)
                {
                    Tab_Pion[i, j] = 1;
                }
            }
        }

        //fonction qui permet de placer les pions noirs sur le plateau de jeu
        static void PionBlanc(ref int[,] Tab_Pion)
        {
            //pour les ligne de 6 => 9
            for (int i = 6; i < 10; i++)
            {
                int StartValue;
                //modulo= paire ou impaire
                if (i % 2 == 0)
                {
                    StartValue = 0;
                }

                else
                {
                    StartValue = 1;
                }

                for (int j = StartValue; j < 10; j = j + 2)
                {
                    Tab_Pion[i, j] = 2;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static void AvancementPionBlanc(ref int[,] Tab_Pion, string joueur1)
        {
            int LignePionBlanc;
            int ColonnePionBlanc;

            Console.WriteLine(joueur1 + " " + "quelle numéro de ligne du pion que vous voulez avancer (Pion 2) ");
            LignePionBlanc = int.Parse(Console.ReadLine());

            Console.WriteLine(joueur1 + " " + "Quelle numéro de colonne du pion que vous voulez avancer (Pion 2) ");
            ColonnePionBlanc = int.Parse(Console.ReadLine());

            if (ColonnePionBlanc == 0)
            {
                //verif case haut droite 
                if (VerifCase(ref Tab_Pion, LignePionBlanc - 1, ColonnePionBlanc + 1))
                {
                    Tab_Pion[LignePionBlanc, ColonnePionBlanc] = 0;
                    Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc + 1] = 2;
                }

            }

            else if (ColonnePionBlanc == 9)
            {
                //verife case haut gauche 
                if (VerifCase(ref Tab_Pion, LignePionBlanc - 1, ColonnePionBlanc - 1))
                {
                    Tab_Pion[LignePionBlanc, ColonnePionBlanc] = 0;
                    Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc - 1] = 2;
                }
            }

            else
            {

                //Boucle pour rejouer si on se trompe sur le déplacement
                // string cond = "non";
                string cond = "oui";
                while (cond == "oui")
                {

                    //demander si aller soit à Gauche ou soit à Droite sinon faux
                    Console.WriteLine("Déplacer le pion gauche ou droite?");
                    string choix = Console.ReadLine();

                    if (choix == "gauche")
                    {
                        if (Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc - 1] == 0)
                        {
                            Tab_Pion[LignePionBlanc, ColonnePionBlanc] = 0;
                            Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc - 1] = 2;
                        }
                        //Fonction pour manger les pion noir

                        //si le pion noir avance sur une case avec un pion blanc dessus (2) alors le pion noir va directement passer 2 case plus loin               
                        if (Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc - 1] == 1)
                        {
                            Tab_Pion[LignePionBlanc, ColonnePionBlanc] = 0;
                            Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc - 1] = 0;
                            Tab_Pion[LignePionBlanc - 2, ColonnePionBlanc - 2] = 2;
                        }
                        cond = "non";
                    }
                    else if (choix == "droite")
                    {
                        if (Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc + 1] == 0)
                        {
                            Tab_Pion[LignePionBlanc, ColonnePionBlanc] = 0;
                            Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc + 1] = 2;
                        }
                        //Fonction pour manger les pion noir

                        //si le pion noir avance sur une case avec un pion blanc dessus (2) alors le pion noir va directement passer 2 case plus loin               
                        if (Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc + 1] == 1)
                        {
                            Tab_Pion[LignePionBlanc, ColonnePionBlanc] = 0;
                            Tab_Pion[LignePionBlanc - 1, ColonnePionBlanc + 1] = 0;
                            Tab_Pion[LignePionBlanc - 2, ColonnePionBlanc + 2] = 2;
                        }
                        cond = "non";
                    }
                    else
                    {
                        Console.WriteLine("commande erroné");
                        Console.WriteLine("");

                        Console.WriteLine("voulez-vous rejouer votre coup ? oui ou non ?");
                        cond = Console.ReadLine();

                        if (Console.ReadLine() == "oui")
                        {
                            cond = "oui";
                        }
                        else
                        {
                            cond = "non";
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static void AvancementPionNoir(ref int[,] Tab_Pion, string joueur2)
        {
            int LignePionNoir;
            int ColonnePionNoir;


            Console.WriteLine(joueur2 + " " + "Quelle numéro de ligne du pion que vous voulez avancer (Pion 1) ");
            LignePionNoir = int.Parse(Console.ReadLine());

            Console.WriteLine(joueur2 + " " + "Quelle numéro de colonne du pion que vous voulez avancer (Pion 1) ");
            ColonnePionNoir = int.Parse(Console.ReadLine());

            if (ColonnePionNoir == 0)
            {
                //verif case haut droite 
                if (VerifCase(ref Tab_Pion, LignePionNoir + 1, ColonnePionNoir + 1))
                {
                    Tab_Pion[LignePionNoir, ColonnePionNoir] = 0;
                    Tab_Pion[LignePionNoir + 1, ColonnePionNoir + 1] = 1;
                }

            }

            else if (ColonnePionNoir == 9)
            {
                //verife case haut gauche 
                if (VerifCase(ref Tab_Pion, LignePionNoir + 1, ColonnePionNoir - 1))
                {
                    Tab_Pion[LignePionNoir, ColonnePionNoir] = 0;
                    Tab_Pion[LignePionNoir + 1, ColonnePionNoir - 1] = 1;
                }

            }
            else
            {
                string cond = "oui";
                while (cond == "oui")
                {
                    //demander si aller soit à Gauche ou soit à Droite sinon faux    
                    Console.WriteLine("Déplacer le pion gauche ou droite?");
                    string choix = Console.ReadLine();

                    if (choix == "gauche")
                    {
                        if (Tab_Pion[LignePionNoir + 1, ColonnePionNoir - 1] == 0)
                        {
                            Tab_Pion[LignePionNoir, ColonnePionNoir] = 0;
                            Tab_Pion[LignePionNoir + 1, ColonnePionNoir - 1] = 1;
                        }
                        //Fonction pour manger les pion blanc

                        //si le pion noir avance sur une case avec un pion blanc dessus (2) alors le pion noir va directement passer 2 case plus loin  
                        if (Tab_Pion[LignePionNoir + 1, ColonnePionNoir - 1] == 2)
                        {
                            //ET si la case 2 ligne plus bas et 2 colonne à gauche est égale à 0 (alors je peux manger le pion adverse)
                            if (Tab_Pion[LignePionNoir + 2, ColonnePionNoir - 2] == 0)
                            {
                                Tab_Pion[LignePionNoir, ColonnePionNoir] = 0;
                                Tab_Pion[LignePionNoir + 1, ColonnePionNoir - 1] = 0;
                                Tab_Pion[LignePionNoir + 2, ColonnePionNoir - 2] = 1;
                            }
                        }
                        cond = "non";
                    }
                    else if (choix == "droite")
                    {
                        if (Tab_Pion[LignePionNoir + 1, ColonnePionNoir + 1] == 0)
                        {
                            Tab_Pion[LignePionNoir, ColonnePionNoir] = 0;
                            Tab_Pion[LignePionNoir + 1, ColonnePionNoir + 1] = 1;
                        }
                        //Fonction pour manger les pion blanc

                        //si le pion noir avance sur une case avec un pion blanc dessus (2) alors le pion noir va directement passer 2 case plus loin  
                        if (Tab_Pion[LignePionNoir + 1, ColonnePionNoir + 1] == 2)
                        {
                            //sinon si la case 2 lignes plus bas et 2 colonne à droite est égale à 0 (alors je peux manger le pion adverse) 
                            if (Tab_Pion[LignePionNoir + 2, ColonnePionNoir + 2] == 0)
                            {
                                Tab_Pion[LignePionNoir, ColonnePionNoir] = 0;
                                Tab_Pion[LignePionNoir + 1, ColonnePionNoir + 1] = 0;
                                Tab_Pion[LignePionNoir + 2, ColonnePionNoir + 2] = 1;
                            }
                        }
                        cond = "non";
                    }
                    else
                    {
                        Console.WriteLine("commande erroné");
                        Console.WriteLine("");

                        Console.WriteLine("voulez-vous rejouer votre coup ? oui ou non ?");
                        cond = Console.ReadLine();

                        if (Console.ReadLine() == "oui")
                        {
                            cond = "oui";
                        }
                        else
                        {
                            cond = "non";
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static bool VerifCase(ref int[,] Tab_Pion, int LignePionBlanc, int ColonnePionBlanc)
        {
            if (Tab_Pion[LignePionBlanc, ColonnePionBlanc] == 2)
            {
                return false;
            }
            return true;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static void Main(string[] args)
        {
            int[,] Tab_Pion = new int[10, 10];
            ConstruireMatrice(ref Tab_Pion);
            PionBlanc(ref Tab_Pion);
            PionNoir(ref Tab_Pion);

            Console.WriteLine(@" 
        
            ____________________________________________________________________________________

                  _                       ____               ____                               
                 | |   ___   _   _       |  _ \    ___      |  _ \    __ _   _ __ ___     ___   
              _  | |  / _ \ | | | |      | | | |  / _ \     | | | |  / _` | | '_ ` _ \   / _ \  
             | |_| | |  __/ | |_| |      | |_| | |  __/     | |_| | | (_| | | | | | | | |  __/  
              \___/   \___|  \__,_|      |____/   \___|     |____/   \__,_| |_| |_| |_|  \___|

            ____________________________________________________________________________________

            ");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine(" Voici le plateau de jeu ");

            Console.WriteLine("");
            Console.WriteLine("");

            AfficherMatrice(Tab_Pion);

            Console.WriteLine("");
            Console.WriteLine("");

            string joueur1;
            Console.WriteLine("joueur 1 comment vous appelé vous?");
            joueur1 = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            string joueur2;
            Console.WriteLine("joueur 2 comment vous appelé vous?");
            joueur2 = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            int finDuJeu = 100;
            for (int i = 0; i <= finDuJeu; i++)
            {

                // Début du jeu ==> faire avancer les pion blanc
                AvancementPionBlanc(ref Tab_Pion, joueur1);
                VerifCase(ref Tab_Pion, 0, 9);

                Console.WriteLine("");
                Console.WriteLine("");

                AfficherMatrice(Tab_Pion);

                Console.WriteLine("");
                Console.WriteLine("");

                AvancementPionNoir(ref Tab_Pion, joueur2);
                VerifCase(ref Tab_Pion, 0, 9);

                Console.WriteLine("");
                Console.WriteLine("");

                AfficherMatrice(Tab_Pion);

                Console.WriteLine("");
                Console.WriteLine("");


            }
        }
    }
}
