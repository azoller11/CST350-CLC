﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperCLC.Models
{
    public class ButtonModel
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int ButtonState { get; set; }
        public int NumberOfNeighbors { get; set; }

        public ButtonModel(int row, int col, int buttonState)
        {
            Row = row;
            Col = col;
            ButtonState = buttonState;
        }

        public ButtonModel(int row, int col, int buttonState, int numberOfNeightbors)
        {
            Row = row;
            Col = col;
            ButtonState = buttonState;
            NumberOfNeighbors = numberOfNeightbors;
        }
    }
}
