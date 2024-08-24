using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Exceptions;

namespace TicTacToe.Models
{
    internal class Board
    {
        public Cell[] cells = new Cell[9];

        public Board()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
                cells[i].CellNumber = i;
            }

        }

        public bool IsBoardFull()
        {
            bool full = true;
            foreach (var item in cells)
            {
                if (item.GetMark() == MarkType.EMPTY)
                    full &= false;
                else
                    full &= true;

            }
            return full;
        }

        public void SetCellMark(int location, MarkType mark)
        {
            if (location > cells.Length || location < 0)
                throw new InvalidCellLocationError("The location that you entered is invalid! Location should be between 0 - 8 !");
            cells[location].SetMark(mark);
            
        }

        public string DisplayGrid()
        {
           return $"\n\n" +
                $"\t\t|\t\t|\n" +
                $"\t{cells[0].DisplayCellNumberOrResult()}\t|\t{cells[1].DisplayCellNumberOrResult()}\t|\t{cells[2].DisplayCellNumberOrResult()}\n" +
                $"\t\t|\t\t|\n" +
                $"    -----------------------------------------\n" +
                $"\t\t|\t\t|\n" +
                $"\t{cells[3].DisplayCellNumberOrResult()}\t|\t{cells[4].DisplayCellNumberOrResult()}\t|\t{cells[5].DisplayCellNumberOrResult()}\n" +
                $"\t\t|\t\t|\n" +
                $"    -----------------------------------------\n" +
                $"\t\t|\t\t|\n" +
                $"\t{cells[6].DisplayCellNumberOrResult()}\t|\t{cells[7].DisplayCellNumberOrResult()}\t|\t{cells[8].DisplayCellNumberOrResult()}\n" +
                $"\t\t|\t\t|\n";
        }
    }
}
