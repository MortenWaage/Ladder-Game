using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadderGame
{
    class Dice
    {
        private readonly Random _rand = new Random();
        public int Roll()
        {
            return _rand.Next(0, 6) + 1;
        }
    }
}