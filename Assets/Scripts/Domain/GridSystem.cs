using System.Linq;
public class GridSystem
{
    private singleストアに値する仕組みが何かある
    // TODO getterだけpublicにしたい
    public Coordinates[,] tiles; こいつらはsingle storeな物を参照し、grid-systemへのactionを発行するクラス
    public Player player;
    public Organoid[] organoid;
    static private GridSystem gridSystem;
    private GridSystem(int columns, int rows)
    {
        tiles = new Coordinates[columns, rows];
        var sequence = from x in Enumerable.Range(0, columns)
                       from y in Enumerable.Range(0, rows)
                       select new { x, y };
        foreach (var index in sequence)
        {
            tiles[index.x, index.y] = new Coordinates(index.x, index.y);
        }
        gridSystem = this;
    }
    static public GridSystem Init(int columns, int rows)
    {
        if (gridSystem != null)
        {
            throw new System.Exception("girdsytem already defined");
        }
        new GridSystem(columns, rows);
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
}

