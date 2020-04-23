using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Round
    {
        public static Random choice;
        private int winner;
        private int p1Choice;
        private int p2Choice;

        public Round()
        {
            choice = new Random();
        }

        public int Winner { get => winner; set => winner = value; }
        public int P1Choice { get => p1Choice; set => p1Choice = value; }
        public int P2Choice { get => p2Choice; set => p2Choice = value; }

        public static int RandomChoice() 
        {
            return choice.Next(3);
        }

        public void Play()
        {
            P1Choice = RandomChoice();
            P2Choice = RandomChoice();

            int win = P1Choice - P2Choice + 2;
            switch (win)
                { //win is mostly unique varying with what each player picks
                    case 0: //p1 rock p2 scissor p1 wins
                        Winner = 1;
                        break;
                    case 1: // p1 lost since result is negative rock(0) - paper(1) or 1 - 2
                        Winner = 2;
                        break;
                    case 2: // tie
                        Winner = 0;
                        break;
                    case 3:// p1 wins as 1 - 0 or 2 - 1;
                        Winner = 1;
                        break;
                    case 4://p1 scissor p2 rock p2 wins
                        Winner = 2;
                        break;
                    default:
                        break;
                }
            return;
        }
    }
}
