Random rand = new Random();
float generateWhiteNoise()
{
    return 2.0f * (Convert.ToSingle(rand.NextDouble()) - 0.5f);        
}

for (int y = 0; y < 20; y++)
{
    for (int x = 0; x < 80; x++)
    {
        double xCoord = (double)x / 80;
        double yCoord = (double)y / 20;
        double value = generateWhiteNoise();

        // Normalize and map the value to your desired range
        Console.Write(value > 0 ? "X" : ".");
    }
    Console.WriteLine();
}
