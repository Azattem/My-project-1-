using Assets.Scripts.Tiles;
using UnityEngine;

public abstract class BaseTile
{
    private string objectPath;
    private BaseCreature creature = null;
    private bool seen = false;
    public BaseTile(string texture)
    {
        objectPath = texture;
    }
    public bool IsSeen()
    {
        return seen;
    }
    public void SetSeen(bool seen)
    {
        this.seen = seen;
    }
    public GameObject CreateObject()
    {
        GameObject tileAsset;
        if (seen)
        {
            tileAsset = Resources.Load(objectPath) as GameObject;
        }
        else
        {
            tileAsset = Resources.Load("NoVision") as GameObject;
        } 
        //if (tileAsset.GetComponent<TileInfo>() == null) {
        //    tileAsset.AddComponent<TileInfo>().setInfo(objectPath, seen);
        //}
        
        //Debug.Log(x+" "+ y);
        return tileAsset;
    }
    public string GetTexture()
    {
        return objectPath;
    }
    public BaseCreature GetCreature()
    {
        return creature;
    }
    public void SetCreature(BaseCreature creature)
    {
        this.creature = creature;
    }
    public bool IsContainsCreature()
    {
        return this.creature != null;
    }
}
