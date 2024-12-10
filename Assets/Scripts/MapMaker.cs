public static class MapMaker
{
    public static Map generateMap(int sizeX, int sizeY)
    {
        Map map = new Map(sizeX, sizeY);
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                map.setTile(i, j, TileTypeManager.GetTileById(1));
            }
        }
        return map;
    }
}
