using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class ResultAnalyzer
    {
        private Board _board;
        private ResultType _result;

        public ResultAnalyzer(Board board, ResultType result)
        {
            _board = board;
            _result = result;
        }

        public void HorizontalWinCheck()
        {
            for (int i = 0; i < _board.cells.Length; i += 3)
            {
                var cellMark1 = _board.cells[i].GetMark();
                var cellMark2 = _board.cells[i + 1].GetMark();
                var cellMark3 = _board.cells[i + 2].GetMark();

                if ((cellMark1 == cellMark2) && (cellMark2 == cellMark3))
                    if ((cellMark1 != MarkType.EMPTY) || (cellMark2 != MarkType.EMPTY) || (cellMark3 != MarkType.EMPTY))
                    {
                        _result = ResultType.WIN;
                        return;
                    }

            }

        }

        public ResultType GetResult()
        {
            return _result;
        }

        public void VerticalWinCheck()
        {
            for (int i = 0; i < 3; i += 1)
            {
                var cellMark1 = _board.cells[i].GetMark();
                var cellMark2 = _board.cells[i + 3].GetMark();
                var cellMark3 = _board.cells[i + 6].GetMark();

                if ((cellMark1 == cellMark2) && (cellMark2 == cellMark3))
                    if ((cellMark1 != MarkType.EMPTY) || (cellMark2 != MarkType.EMPTY) || (cellMark3 != MarkType.EMPTY))
                    {
                        _result = ResultType.WIN;
                        return;
                    }
            }

        }
        public void DiagnolWinCheck()
        {
            var cellMark1 = _board.cells[0].GetMark();
            var cellMark2 = _board.cells[4].GetMark();
            var cellMark3 = _board.cells[8].GetMark();

            var cellMark4 = _board.cells[2].GetMark();
            var cellMark5 = _board.cells[6].GetMark();


            if ((cellMark1 == cellMark2) && (cellMark2 == cellMark3))
                if ((cellMark1 != MarkType.EMPTY) || (cellMark2 != MarkType.EMPTY) || (cellMark3 != MarkType.EMPTY))
                {
                    _result = ResultType.WIN;
                    return;
                }

            if ((cellMark4 == cellMark2) && (cellMark2 == cellMark5))
                if ((cellMark4 != MarkType.EMPTY) || (cellMark2 != MarkType.EMPTY) || (cellMark5 != MarkType.EMPTY))
                {
                    _result = ResultType.WIN;
                    return;
                }

        }

        public ResultType AnalyzeResult()
        {
            HorizontalWinCheck();
            if (_result == ResultType.WIN)
                return ResultType.WIN;
            VerticalWinCheck();
            if (_result == ResultType.WIN)
                return ResultType.WIN;
            DiagnolWinCheck();
            if (_result == ResultType.WIN)
                return ResultType.WIN;

            if (_board.IsBoardFull())
                return ResultType.DRAW;
            return ResultType.PROGRESS;


        }
    }
}
