using System;
using System.Collections.Generic;
using System.Linq;

namespace HeritageEtInterfaceCorrection
{
    class FightManager
    {
        public List<Character> charactersList = new List<Character>();
        public int round = 0;
        public DateTime startTime;
        public int StartNumberFighter = 0;
        public bool continueFight = false;
        //public int PlayingPlayerIndex = 0;
        bool fightEnded = false;

        public FightManager(List<Character> charactersList, int round = 0)
        {
            this.charactersList = charactersList;
            this.round = round;
            foreach (Character character in charactersList)
            {
                character.SetFightManager(this);
            }
        }

        public void StartCombat()
        {
            startTime = DateTime.Now;
            round = 1;
            StartNumberFighter = charactersList.Count;
            //faire en sorte que les personnages ne soient pas blessé avant le début du combat
            foreach (Character personnage in charactersList)
            {
                personnage.Reset();
            }
            MyLog("----- Debut du combat -----");
            //a commenter pour enchainer les rounds à la main
            //faire des rounds tant qu'il y a plus d'un combattant vivant
            while (charactersList.Count > 1)
            {
                StartRound();
                if (fightEnded)
                {
                    return;
                }
            }

            ManageVictory();
        }

        void ManageVictory()
        {
            fightEnded = true;
            if (charactersList.Count == 1)
            {
                MyLog(charactersList[0].Name + " remporte le battle royale");
            }
            else if (charactersList.Count <= 0)
            {
                MyLog("Tout le monde est mort, il n'y a pas de vainqueur");
            }
        }

        public void StartRound(bool waitInput = false)
        {

            MyLog("---------- Round " + round + " ----------");

            foreach (Character p in charactersList)
            {
                //reinitialiser les variables nécessaires
                p.RoundReset();
                //calculer l'initiative pour ce round
                p.CalculateInitiative();
            }

            //classer les différents personnage en fonction de initiative
            charactersList = charactersList.OrderByDescending(personnage => personnage.CurrentInitiative).ToList();


            for (int i = 0; i < charactersList.Count; i++)
            {
                //on stocke le personnage dans une variable pour éviter d'accéder inutilement à la liste
                Character currentPersonnage = charactersList[i];
                //si le personnage peut attaquer et qu'il est vivant
                if (currentPersonnage.CanAttack && currentPersonnage.CurrentAttackNumber > 0 && currentPersonnage.CurrentLife > 0)
                {
                    while (currentPersonnage.CurrentAttackNumber > 0 && currentPersonnage.CanAttack)
                    {
                        //choisir une cible puis attaquer
                        currentPersonnage.SelectTargetAndAttack();
                    }
                }
                else if (currentPersonnage.CurrentAttackNumber == 0 && currentPersonnage.CurrentLife > 0)
                {
                    MyLog(currentPersonnage.Name + " n'a plus d'attaques disponibles et ne peut rien faire pendant ce round.");
                }
            }

            //on fait une deuxième boucle sur les personnage pour retirer les morts de la liste
            //on fait cette boucle de la fin vers le début pour éviter les problèmes que l'on rencontre quand on modifie 
            //une liste sur laquelle on est en train d'itérer
            int deadInRound = 0;
            for (int i = charactersList.Count - 1; i >= 0; i--)
            {
                //on stocke le personnage dans une variable pour éviter d'accéder inutilement à la liste
                Character currentPersonnage = charactersList[i];
                if (currentPersonnage.CurrentLife <= 0)
                {
                    charactersList.Remove(currentPersonnage);
                    deadInRound++;
                }
            }

            foreach (Character c in charactersList)
            {
                IScavenger current = c as IScavenger;
                if (current != null)
                {
                    for (int i = 0; i < deadInRound; i++)
                    {
                        current.EatBody();
                    }
                }
            }

            MyLog("---------- Fin du round ----------");

            round++;
        }

        public static void MyLog(string text)
        {
            Console.WriteLine(text);
        }
        
    }
}
