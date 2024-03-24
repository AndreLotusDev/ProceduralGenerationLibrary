int width = 80;
int height = 20;
char[,] map = new char[width, height];

void GenerateHeatMap()
{
    // Simple gradient for heat map: left (low value) to right (high value)
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            // Use a simple function to generate gradient; you could use Perlin noise for more natural patterns
            double value = (double)x / width;
            map[x, y] = value > 0.5 ? '.' : ' '; // '.' for potential vegetation areas
        }
    }
}

void SimulateVegetationGrowth()
{
    Random rand = new Random();
    // Introduce a probability factor for vegetation growth in suitable areas
    double growthProbability = 0.5; // 50% chance

    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            if (map[x, y] == '.' && rand.NextDouble() < growthProbability)
            {
                // With a certain probability, replace '.' with 'T' for tree
                map[x, y] = 'T';
            }
        }
    }
}


void PrintMap()
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            Console.Write(map[x, y]);
        }
        Console.WriteLine();
    }
}

GenerateHeatMap();
SimulateVegetationGrowth();
PrintMap();
