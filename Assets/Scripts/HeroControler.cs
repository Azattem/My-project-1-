using UnityEngine;

public class HeroControler : MonoBehaviour
{
    private GameMaster master;
    private BaseCreature hero;

    public int drawDistance;
    public void setMaster(GameMaster master)
    {
        this.master = master;
    }
    public int getDrawDistance()
    {
        return drawDistance;
    }
    public BaseCreature getHeroCreature()
    {
        return hero;
    }
    public void setHero(BaseCreature creature)
    {
        hero = creature;
    }
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            if (moveHeroX(1))
            {
                master.EndTurn();
            }
        }
        if (Input.GetKeyDown("s"))
        {
            if (moveHeroX(-1))
            {
                master.EndTurn();
            }
        }
        if (Input.GetKeyDown("a"))
        {
            if (moveHeroY(-1))
            {
                master.EndTurn();
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (moveHeroY(+1))
            {
                master.EndTurn();
            }
        }

    }

    private bool moveHeroX(int x)
    {
        if (master.MoveCreature(hero, hero.getX() + x, hero.getY()))
        {
            return true;
        }
        return false;
    }
    private bool moveHeroY(int y)
    {

        if (master.MoveCreature(hero, hero.getX(), hero.getY() + y))
        {
            return true;
        }
        return false;
    }


}