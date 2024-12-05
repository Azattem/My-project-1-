using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class TileTypeManager  {
    private static Dictionary<string, KeyValuePair<BaseTile, GameObject>> dataDictionary = new();

    public static BaseTile GetTileById(string id) {

        return dataDictionary[id].Key;
    }
    public static GameObject GetSpriteById(string id) {
        return dataDictionary[id].Value;
    }
    public static void AddTileToData(BaseTile tile) { 
    
    }
    private static void GetInfoFromFile(string filePath) { 
    
    }
}
