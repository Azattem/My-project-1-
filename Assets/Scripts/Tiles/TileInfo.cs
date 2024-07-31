using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Scripts.Tiles
{
    public class TileInfo : MonoBehaviour
    {
        public string tileName;
        public bool isSeen;
        public void setInfo(string tileName, bool isSeen)
        {
            this.tileName = tileName;
            this.isSeen = isSeen;
        }

    }
}