public class BasicTile : BaseTile
{
    public BasicTile(BaseTile baseTile) : base(baseTile) {
    }

    public BasicTile(int id,string name,string texture) : base(id, name,texture)
    {

    }

    public override BaseTile Copy() {
        return new BasicTile(this);
    }
}
