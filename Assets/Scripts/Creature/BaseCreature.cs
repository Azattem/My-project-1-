using UnityEngine;

public abstract class BaseCreature
{
    private string objectPath;
    private int x;
    private int y;

    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    public void setCord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public GameObject createObject()
    {
        GameObject CreatureAsset = Resources.Load(objectPath) as GameObject;
        //Debug.Log(x+" "+ y);
        return CreatureAsset;
    }
    public BaseCreature(string texture)
    {
        objectPath = texture;
    }

}
