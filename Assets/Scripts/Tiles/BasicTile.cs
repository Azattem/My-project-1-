public class BasicTile : BaseTile
{
    public BasicTile(BaseTile baseTile) : base(baseTile) {
    }

    public BasicTile(int id,string texture) : base(id,texture)
    {

    }

    public override BaseTile Copy() {
        return new BasicTile(this);
    }
}
