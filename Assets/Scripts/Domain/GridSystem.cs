using System.Linq;
public class GridSystem
{
    Coordinates[,] tiles;
    static private GridSystem gridSystem;
    static public GridSystem Init(int column, int row)
    {
        if (gridSystem != null)
        {
            throw new System.Exception("girdsytem already defined");
        }
        new GridSystem(column, row);
        return gridSystem;
    }

    static public GridSystem GetInstance()
    {
        if (gridSystem == null)
        {
            throw new System.Exception("girdsytem shoudl be init");
        }
        return gridSystem;
    }
    private GridSystem(int column, int row)
    {
        tiles = new Coordinates[column, row];
        var sequence = from x in Enumerable.Range(0, column)
                       from y in Enumerable.Range(0, row)
                       select new { x, y };
        foreach (var index in sequence)
        {
            tiles[index.x, index.y] = new Coordinates();
        }
        gridSystem = this;
    }
}

