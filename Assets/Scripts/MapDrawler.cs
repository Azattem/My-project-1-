using System.Collections.Generic;
using UnityEngine;

public class MapDrawler : MonoBehaviour
{
    private GameMaster master;
    private Map currentMap;
    private int drawDistance;
    private BaseTile[,] drawDistanceMap;
    private const int memLengSize = 2;
    private Dictionary<BaseTile, List<GameObject>> objectMap = new();

    public void SetMaster(GameMaster master)
    {
        this.master = master;
        currentMap = master.GetCurrentMap();
    }
    public void ResetCurrentMap()
    {
        currentMap = master.GetCurrentMap();
    }
    public void SetDrawDist(int drawDistance)
    {
        this.drawDistance = drawDistance;
        drawDistanceMap = new BaseTile[(drawDistance + memLengSize) * 2 - 1, (drawDistance + memLengSize) * 2 - 1];
    }
    public void Draw()
    {
        int XS = master.GetHeroX();
        int YS = master.GetHeroY();
        //Debug.Log(XS + " " + YS);
        ResetCurrentMap();
        PopulateDrawMap(XS, YS);
        PlaceObjects(XS, YS);
    }
    private bool DestroyObject(BaseTile tile)
    {
        if (objectMap.ContainsKey(tile))
        {
            foreach (GameObject obj in objectMap[tile])
            {
                Destroy(obj);
            }

            objectMap.Remove(tile);
            return true;
        }
        return false;

    }
    private bool DestroyTileAsset(BaseTile tile)
    {
        if (objectMap.ContainsKey(tile))
        {
            if (objectMap[tile][0] != null)
            {
                Destroy(objectMap[tile][0]);
                objectMap[tile][0] = null;
                return true;
            }
        }
        return false;
    }
    private bool DestroyCreature(BaseTile tile)
    {
        if (objectMap.ContainsKey(tile))
        {
            // Debug.Log(objectMap[tile][1]);
            if (objectMap[tile][1] != null)
            {
                Destroy(objectMap[tile][1]);
                objectMap[tile][1] = null;
                return true;
            }
        }
        return false;

    }
    //Создание карты для отрисовки на основе карты взятое у мастера
    private void PopulateDrawMap(int XS, int YS)
    {
        int x = 0;
        int y = 0;
        int centre = drawDistance;
        for (int i = XS - centre; i <= XS + centre; i++)
        {
            for (int j = YS - centre; j <= YS + centre; j++)
            {
                if (currentMap.getTile(i, j) != null)
                {
                    drawDistanceMap[x, y] = currentMap.getTile(i, j);
                    //отрисовка геометричесокго ромба
                    if ((x >= centre - y+1 && x <= centre + y-1) && y <= centre)
                    {
                        drawDistanceMap[x, y].SetSeen(true);
                    }
                    else if ((x >= y - centre+1&& x <= centre * 2 - (y - centre)-1) && y > centre)
                    {
                        drawDistanceMap[x, y].SetSeen(true);
                    }
                    else
                    {
                        drawDistanceMap[x, y].SetSeen(false);
                    }

                }
                else
                {
                    drawDistanceMap[x, y] = new NothingTile();
                    drawDistanceMap[x, y].SetSeen(true);
                }
                x++;
            }
            x = 0;
            y++;
        }
        //DebugTooles.soutMassive(drawDistanceMap);
    }
    private void PlaceObjects(int heroX, int heroY)
    {
        for (int i = 0; i < drawDistanceMap.GetLength(0); i++)
        {
            for (int j = 0; j < drawDistanceMap.GetLength(1); j++)
            {
                if (drawDistanceMap[i, j] != null)
                {
                    //Debug.Log(drawDistanceMap.GetLength(1) + " " + drawDistanceMap.GetLength(0));
                    BaseTile curTile = drawDistanceMap[i, j];
                    if (!objectMap.ContainsKey(curTile))
                    {
                        GameObject tileAsset = curTile.CreateObject();
                        tileAsset = Instantiate(tileAsset, new Vector3((i + heroY) * tileAsset.transform.localScale.x, 0, (j + heroX) * tileAsset.transform.localScale.z), Quaternion.identity);
                        objectMap.Add(curTile, new List<GameObject> { tileAsset, null, null });
                        curTile.SetLastSeen(curTile.IsSeen());
                    }
                    if (curTile.IsSeen() != curTile.IsLastSeen())
                    {
                        //Debug.Log("s");
                        curTile.SetLastSeen(curTile.IsSeen());
                        DestroyTileAsset(curTile);
                        GameObject tileAsset = curTile.CreateObject();
                        tileAsset = Instantiate(tileAsset, new Vector3((i + heroY) * tileAsset.transform.localScale.x, 0, (j + heroX) * tileAsset.transform.localScale.z), Quaternion.identity);
                        objectMap[curTile][0] = tileAsset;
                    }


                    if (curTile.IsContainsCreature()&&curTile.IsSeen())
                    {
                        if (objectMap[curTile][1] == null)
                        {
                            //Debug.Log(drawDistanceMap[i, j].getCreature().getX()+" "+ drawDistanceMap[i, j].getCreature().getY());
                            GameObject creatureAsset = curTile.GetCreature().createObject();
                            GameObject tileAsset = objectMap[curTile][0];
                            creatureAsset = Instantiate(creatureAsset, new Vector3((i + heroY) * tileAsset.transform.localScale.x, tileAsset.transform.localScale.y / 2 + creatureAsset.transform.localScale.y / 2, (j + heroX) * tileAsset.transform.localScale.z), Quaternion.identity);
                            objectMap[curTile][1] = creatureAsset;
                        }
                    }
                    else
                    {
                        DestroyCreature(curTile);
                    }

                }
            }
        }
    }
}
