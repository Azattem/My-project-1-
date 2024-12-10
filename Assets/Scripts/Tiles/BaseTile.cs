using Assets.Scripts.Tiles;
using UnityEngine;

public abstract class BaseTile
{
    private string objectPath;
    private BaseCreature creature = null;
    private bool seen = false;
    private bool lastSeen = false;
    private int id;
    public BaseTile(int id,string texture)
    {
        this.id = id;
        objectPath = texture;
    }
    public BaseTile(BaseTile baseTile) {
    this.id = baseTile.id;
    this.objectPath = baseTile.objectPath;
    }
    public bool IsSeen()
    {
        return seen;
    }
    public void SetSeen(bool seen)
    {
        this.seen = seen;
    }
    public bool IsLastSeen()
    {
        return lastSeen;
    }
    public void SetLastSeen(bool lastSeen)
    {
        this.lastSeen = lastSeen;
    }
    public GameObject CreateObject()
    {
        GameObject tileAsset;
        if (seen)
        {
            tileAsset = TileTypeManager.GetSpriteById(id);
        }
        else
        {
            tileAsset = TileTypeManager.GetSpriteById(0);
        } 
        return tileAsset;
    }
    public string Getsprite()
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
    public abstract BaseTile Copy();
}
