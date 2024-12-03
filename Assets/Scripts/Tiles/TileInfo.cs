using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Scripts.Tiles
{
    public class TileInfo : MonoBehaviour
    {
        public string tileName;

        public void setInfo(string tileName)
        {
            this.tileName = tileName;

        }

    }
}