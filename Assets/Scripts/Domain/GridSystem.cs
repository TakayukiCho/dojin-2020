using System.Linq;
public class GridSystem
{
    Coordinates[,] tiles;
    GridSystem(int column, int row)
    {
        tiles = new Coordinates[column, row];
        var sequence = from x in Enumerable.Range(0, column)
                       from y in Enumerable.Range(0, row)
                       select new { x, y };
        foreach (var index in sequence)
        {
            tiles[index.x, index.y] = new Coordinates();
        }
    }
}
