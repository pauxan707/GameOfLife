namespace Ucu.Poo.GameOfLife;

public static class GameLogic
{
    public static Board CalculateNextGeneration(Board currentBoard)
    {
        int width = currentBoard.Width;
        int height = currentBoard.Height;
        bool[,] currentGrid = currentBoard.Grid;
        bool[,] newGrid = new bool[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int liveNeighbors = CountLiveNeighbors(currentGrid, x, y, width, height);
                bool isAlive = currentGrid[y, x];

                // Aplicar reglas de Conway
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

        return new Board(width, height) { Grid = newGrid };
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