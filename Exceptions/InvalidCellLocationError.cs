using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Exceptions
{
    internal class InvalidCellLocationError:Exception
    {
        public InvalidCellLocationError(string message):base(message)
        {
            
        }
    }
}
