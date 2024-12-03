using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Map currentMap;
    public HeroControler heroControler;
    public MapDrawler drawler;
    public int currentTurn = 100;

    // Start is called before the first frame update
    void Start()
    {
        this.currentMap = MapMaker.generateMap(20, 20);
        heroControler.setMaster(this);
        heroControler.setHero(new HeroCreature());
        drawler.SetMaster(this);
        SpawnCreature(heroControler.getHeroCreature(), 1, 1);
        SpawnCreature(new EnemyCreature("Wolf"), 2, 2);
        drawler.SetDrawDist(heroControler.getDrawDistance());
        drawler.Draw();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Map GetCurrentMap()
    {
        return currentMap;
    }
    public int GetHeroX()
    {
        return heroControler.getHeroCreature().getX();
    }
    public int GetHeroY()
    {
        return heroControler.getHeroCreature().getY();
    }
    public BaseCreature SpawnCreature(BaseCreature creature, int x, int y)
    {
        creature.setCord(x, y);
        currentMap.getTile(x, y).SetCreature(creature);
        return creature;
    }
    public void EndTurn()
    {
        currentTurn--;
        //Debug.Log(currentTurn);
        drawler.Draw();
    }
    public bool MoveCreature(BaseCreature creature, int x, int y)
    {
        if (currentMap.getTile(x, y) != null && currentMap.getTile(x, y).GetCreature() == null)
        {
            currentMap.getTile(creature.getX(), creature.getY()).SetCreature(null);
            currentMap.getTile(x, y).SetCreature(creature);
            creature.setCord(x, y);

            return true;
        }
        return false;
    }


}
