using System.IO;

namespace Ucu.Poo.GameOfLife;

public class FileReader //Consideramos que cumple con SRP porque su única responsabilidad y motivo de cambio es la lectura de un archivo y su conversión a array. Es Expert porque es la clase que "conoce" el archivo .txt, y es la que lo manipula.
{
    public static bool[,] ReadFile(string route)
    {
        string content = File.ReadAllText(route);
        string[] contentLines = content.Split('\n');
        bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
        for (int y = 0; y < contentLines.Length; y++)
        {
            for (int x = 0; x < contentLines[y].Length; x++)
            {
                if (contentLines[y][x] == '1')
                {
                    board[x, y] = true;
                }
            }
        }

        return board;
    }
}
   