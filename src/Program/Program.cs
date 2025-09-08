using System;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] board = FileReader.ReadFile("board.txt");
            while (true)
            {
                
                GamePrinter.Print(board);
                board = GameLogic.CalculateNextGeneration(board);
                Thread.Sleep(300);
                
            }
        }
    }
}
