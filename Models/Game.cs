using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class Game
    {
        public static Player[] Players = new Player[2] {new Player { Name = "Sufyan", Mark = MarkType.X},
            new Player { Mark = MarkType.O, Name = "AI" } };
        private static ResultAnalyzer _resultAnalyzer;
        private static Board _board;

        static Player currentPlayer = Players[1];
        static ResultType analyseResult;

        public Game()
        {
            _board = new Board();
            _resultAnalyzer = new ResultAnalyzer(_board, ResultType.PROGRESS);
        }
        public void RunGame()
        {
            analyseResult = _resultAnalyzer.GetResult();
            while (analyseResult != ResultType.WIN && analyseResult != ResultType.DRAW)
            {
                bool error = true;
                currentPlayer = (currentPlayer == Players[0]) ? Players[1] : Players[0];
                while (error)
                    error = SettingMarkAndAnalyzing();
            }
            DisplayResult();
        }

        public static bool SettingMarkAndAnalyzing()
        {
            try
            {
                Console.WriteLine(_board.DisplayGrid());
                Console.Write($"Where do you want to place your mark {currentPlayer.Name}: ");
                int position = Convert.ToInt32(Console.ReadLine());
                _board.SetCellMark(position, currentPlayer.Mark);
                analyseResult = _resultAnalyzer.AnalyzeResult();
                return false;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return true;
            }
        }

        public static void DisplayResult()
        {
            if (analyseResult == ResultType.DRAW)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo Winners! It's a Draw!\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(_board.DisplayGrid() + "\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{currentPlayer.Name} has won!:)");
                currentPlayer = (currentPlayer == Players[0]) ? Players[1] : Players[0];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{currentPlayer.Name} you lose! :(");
                Console.ResetColor();
            }
        }
    }
}
