﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public Player(string name, string mark)
        {
            Name = name;
            Mark = mark;
        }

        public string Name { get; set; }
        public string Mark { get; set; }
    }
}
