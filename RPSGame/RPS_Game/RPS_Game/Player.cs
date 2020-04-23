using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Player
    {
		private string name;
		private int wins;
		private int losses;

		public string Name { get => name; set => name = value; }
		public int Wins { get => wins; set => wins = value; }	
		public int Losses { get => losses; set => losses = value; }
	}
}