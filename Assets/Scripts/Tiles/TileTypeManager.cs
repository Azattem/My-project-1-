using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class TileTypeManager  {
    private static Dictionary<int, KeyValuePair<BaseTile, GameObject>> dataDictionary = new();

    public static BaseTile GetTileById(int id) {

        return dataDictionary[id].Key.Copy();
    }
    public static GameObject GetSpriteById(int id) {
        return dataDictionary[id].Value;
    }
    public static void AddTileToData(int id,BaseTile tile) {
        dataDictionary.Add(id, new KeyValuePair<BaseTile, GameObject> (tile, Resources.Load(tile.GetSprite()) as GameObject));
    }
    public static void GetInfoFromFile(string FileName) {
        TextAsset File = (TextAsset)Resources.Load(FileName);
        string text = File.text;

        
        AddTileToData(0,new BasicTile(0,"No Vision", "NoVision"));
        AddTileToData(1, new BasicTile(1, "Empty Tile", "BaseTile"));
    }
}
