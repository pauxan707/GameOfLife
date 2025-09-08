using System;
using System.Text;

namespace Ucu.Poo.GameOfLife;

public class GamePrinter //Creemos que usa correctamente SRP debido a que su única responsabilidad y motivo posible de cambio es el imprimir a consola, incluso la velocidad se controla externamente. No usa tanto Expert, ya que su método utiliza el array que describe el board a imprimir, y naturalmetne este se obtiene en otras clases.
{
    public static void Print(bool[,] board)
    {
        Console.Clear();
        StringBuilder s = new StringBuilder();
        for (int y = 0; y<board.GetLength(0);y++)
        {
            for (int x = 0; x<board.GetLength(1); x++)
            {
                if(board[y, x])
                {
                    s.Append("|X|");
                }
                else
                {
                    s.Append("___");
                }
            }
            s.Append("\n");
        }
        Console.WriteLine(s.ToString());
    }
}