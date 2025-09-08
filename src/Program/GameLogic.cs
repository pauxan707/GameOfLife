namespace Ucu.Poo.GameOfLife;

public static class GameLogic //A pesar de tener dos métodos, uno es complementario del principal, y engloban la misma responsabilidad de aplicar las reglas a un tablero. Por lo tanto, la única manera de que cambie es si cambia la lógica fundamental del juego, por lo tanto cumple con SRP. Luego, en cuanto a Expert, la cumple bastante ya que es la clase que conoce los "live neighbours", y es la que los utiliza.
{
    public static bool[,] CalculateNextGeneration(bool[,] currentBoard)
    {
        int width = currentBoard.GetLength(1);
        int height = currentBoard.GetLength(0);
        bool[,] currentGrid = currentBoard;
        bool[,] newGrid = new bool[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int liveNeighbors = CountLiveNeighbors(currentGrid, x, y, width, height);
                bool isAlive = currentGrid[y, x];

                
                if (isAlive && liveNeighbors < 2)
                    newGrid[y, x] = false;
                else if (isAlive && liveNeighbors > 3)
                    newGrid[y, x] = false;
                else if (!isAlive && liveNeighbors == 3)
                    newGrid[y, x] = true;
                else
                    newGrid[y, x] = isAlive;
            }
        }

        return newGrid;
    }

    private static int CountLiveNeighbors(bool[,] grid, int x, int y, int width, int height)
    {
        int count = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int col = (x + i + width) % width;
                int row = (y + j + height) % height;

                if (grid[row, col])
                    count++;
            }
        }
        return count;
    }
}