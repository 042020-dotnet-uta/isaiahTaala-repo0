using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Game
    {
        public static string[] Choices = { "rock", "paper", "scissors" };
        private Player p1;
        private Player p2;
        private int currentRoundNumber;
        public Game()
        {
            P1 = new Player();
            P2 = new Player();
            rounds = new List<Round>();
            currentRoundNumber = 1;
        }

        private List<Round> rounds;
        public int CurrentRoundNumber { get => currentRoundNumber; set => currentRoundNumber = value; }
        public Player P1 { get => p1; set => p1 = value; }
        public Player P2 { get => p2; set => p2 = value; }

        public void AddRound( Round round )
        {
            rounds.Add( round );
            return;
        }

        public string RoundResult( Round round, int roundNumber, string winnerName )
        {
            return $"Round {roundNumber} - " +
            $"{P1.Name} chose {Choices[round.P1Choice]}, " +
            $"{P2.Name} chose {Choices[round.P2Choice]} " + 
            ( (winnerName != null ) ? $" - {winnerName} won" : $" - no winner" );
            
        }

        public bool WinnerExists()
        {
            int ties = CurrentRoundNumber - ( P1.Wins + P2.Wins );

            if (P1.Wins > 1)
            {    // print results and message stating player 1 wins
                Console.WriteLine($"{P1.Name} Wins {P1.Wins} - {P2.Wins} with {ties} ties.");
            }
            else if (P2.Wins > 1)
            { // print results and message staring player 2 wins
                Console.WriteLine($"{P2.Name} Wins {P2.Wins} - {P1.Wins} with {ties} ties.");
            }
            else
            {
                CurrentRoundNumber++;
                return false;
            }
            return true;
        }
        public void Play()
        {
            Console.WriteLine("Enter Player1 Name: "); //prompts user to input player 1 name
            P1.Name = Console.ReadLine(); //takes input from user and stores it as player 1 name
            Console.WriteLine("Enter Player2 Name: "); //prompts user to input player 2 name
            P2.Name = Console.ReadLine(); //takes input from user and stores it as player 2 name

            while(true)
            {
                Round round = new Round();
                
                round.Play();
                AddRound( round );

                if( round.Winner == 1 )
                {
                    P1.Wins++;
                    P2.Losses++;
                    Console.WriteLine( RoundResult( round, CurrentRoundNumber, P1.Name ) );
                } 
                else if( round.Winner == 2 )
                {
                    P1.Losses++;
                    P2.Wins++;
                    Console.WriteLine( RoundResult( round, CurrentRoundNumber, P2.Name ) );
                }
                else {
                    Console.WriteLine( RoundResult( round, CurrentRoundNumber, null ) );
                }
                
                if( WinnerExists() ) return;
            }
        }
    }
}
