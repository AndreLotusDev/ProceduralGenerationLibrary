static void GenerateTerrain(int width, int height, float scale)
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            float xCoord = x * scale;
            float yCoord = y * scale;
            float sample = PerlinNoise(xCoord, yCoord);
            Console.Write(sample > 0.5 ? "X" : ".");
        }

        Console.WriteLine();
    }
}

static float PerlinNoise(float x, float y)
{
    Random rand = new Random((int)(x + y * 57));
    return (float)rand.NextDouble();
}

int width = 80;
int height = 20;
float scale = 0.1f;

GenerateTerrain(width, height, scale);
