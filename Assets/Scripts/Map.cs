
public class Map
{

    private BaseTile[,] map;
    public Map(int sizeX, int sizeY)
    {
        map = new BaseTile[sizeX, sizeY];
    }
    public void setTile(int x, int y, BaseTile tile)
    {
        map[x, y] = tile;
    }
    public BaseTile getTile(int x, int y)
    {
        //Debug.Log(x + " " + y + " " + map.GetLength(0));
        if (x > map.GetLength(0) - 1 || y > map.GetLength(1) - 1 || x < 0 || y < 0)
        {
            return null;
        }
        return map[x, y];
    }
    public int getSizeX()
    {
        return map.GetLength(0);
    }
    public int getSizeY()
    {
        return map.GetLength(1);
    }
}
