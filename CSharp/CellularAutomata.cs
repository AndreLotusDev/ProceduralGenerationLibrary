int width = 80;
int height = 20;
int fillProbability = 45;
int[,] map;

void InitializeMap()
{
    map = new int[width, height];
    Random rand = new Random();
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                map[x, y] = 1;
            else
                map[x, y] = (rand.Next(0, 100) < fillProbability) ? 1 : 0;
        }
    }
}

void ApplyCellularAutomataRules()
{
    int[,] newMap = new int[width, height];
    for (int y = 1; y < height - 1; y++)
    {
        for (int x = 1; x < width - 1; x++)
        {
            int neighbours = CountAliveNeighbours(x, y);
            if (map[x, y] == 1)
                newMap[x, y] = (neighbours < 3) ? 0 : 1;
            else
                newMap[x, y] = (neighbours > 4) ? 1 : 0;
        }
    }
    map = newMap;
}

int CountAliveNeighbours(int x, int y)
{
    int count = 0;
    for (int i = -1; i <= 1; i++)
    {
        for (int j = -1; j <= 1; j++)
        {
            int neighbourX = x + i;
            int neighbourY = y + j;
            var skipCenterCell = i == 0 && j == 0;
            if (skipCenterCell)
                continue;

            var outOfBoundsAsFilled = neighbourX < 0 || neighbourY < 0 || neighbourX >= width || neighbourY >= height;
            if (outOfBoundsAsFilled)
                count++;
            else if (map[neighbourX, neighbourY] == 1)
                count++;
        }
    }
    return count;
}

void PrintMap()
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            Console.Write(map[x, y] == 1 ? "#" : " ");
        }
        Console.WriteLine();
    }
}

InitializeMap();
for (int i = 0; i < 5; i++)
{
    ApplyCellularAutomataRules();
}
PrintMap();
