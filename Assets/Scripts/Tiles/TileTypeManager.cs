using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class TileTypeManager  {
    private static Dictionary<int, KeyValuePair<BaseTile, GameObject>> dataDictionary = new();
    private static int idCounter = 0;

    public static BaseTile GetTileById(int id) {

        return dataDictionary[id].Key.Copy();
    }
    public static GameObject GetSpriteById(int id) {
        return dataDictionary[id].Value;
    }
    public static void AddTileToData(BaseTile tile) {
        dataDictionary.Add(idCounter, new KeyValuePair<BaseTile, GameObject> (tile, Resources.Load(tile.Getsprite()) as GameObject));
        idCounter++;
    }
    public static void GetInfoFromFile() {
        AddTileToData(new BasicTile(0, "NoVision"));
        AddTileToData(new BasicTile(1, "BaseTile"));
    }
}
