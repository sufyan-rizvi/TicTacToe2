using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Exceptions;


namespace TicTacToe.Models

{
    internal class Cell
    {
        private MarkType _type;
        public int CellNumber {  get; set; }
        
        public MarkType GetMark()
        {
            return _type;
        }

        public void SetMark(MarkType mark)
        {
            
            if (_type != MarkType.EMPTY)
                throw new CellAlreadyMarkedException("The Cell is already Marked !");
            _type = mark;

        }

        public Cell()
        {
            _type = MarkType.EMPTY;
        }

        public bool IsEmpty()
        {
            return GetMark() == MarkType.EMPTY;
        }

        public string DisplayCellNumberOrResult()
        {
            if (_type == MarkType.EMPTY)
                return CellNumber.ToString();
            return _type.ToString();
        }
    }
}
