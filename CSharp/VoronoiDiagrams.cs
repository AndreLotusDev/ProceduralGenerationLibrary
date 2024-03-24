
int width = 80;
int height = 80;
char[,] map = new char[width, height];
List<Point> sites = new List<Point>();
Random rand = new Random();

void InitializeMap()
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            map[x, y] = ' ';
        }
    }
}

void GenerateSites(int count)
{
    for (int i = 0; i < count; i++)
    {
        sites.Add(new Point(rand.Next(width), rand.Next(height)));
    }
}

void CalculateVoronoi()
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            int closestSiteIndex = FindClosestSiteIndex(x, y);
            if (IsOnSite(x, y, closestSiteIndex))
            {
                map[x, y] = 'X'; // Mark the site location or its closest point
            }
        }
    }
}

int FindClosestSiteIndex(int x, int y)
{
    double minDist = double.MaxValue;
    int closestIndex = 0;
    for (int i = 0; i < sites.Count; i++)
    {
        double dist = Math.Sqrt(Math.Pow(sites[i].X - x, 2) + Math.Pow(sites[i].Y - y, 2));
        if (dist < minDist)
        {
            minDist = dist;
            closestIndex = i;
        }
    }
    return closestIndex;
}

bool IsOnSite(int x, int y, int siteIndex)
{
    return sites[siteIndex].X == x && sites[siteIndex].Y == y;
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

InitializeMap();
GenerateSites(5); // Generate 5 random sites
CalculateVoronoi();
PrintMap();

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

