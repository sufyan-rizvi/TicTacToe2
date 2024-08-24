using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Exceptions
{
    internal class CellAlreadyMarkedException:Exception
    {
        public CellAlreadyMarkedException(string message):base(message)
        {
            
        }
    }
}
