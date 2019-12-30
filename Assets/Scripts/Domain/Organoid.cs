
public class Organoid
{
    private Coordinates coordinates;
    private GridSystem gridSystem;
    Organoid(Coordinates coordinates)
    {
        this.coordinates = coordinates;
        this.gridSystem = GridSystem.GetInstance();
    }
}
