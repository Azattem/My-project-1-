public class BasicTileFactory {
    int id;
    string name;
    string texture ;

    public void SetId(int id) { this.id = id; }
    public void SetName(string name) {  this.name = name; }
    public void SetTexture(string texture) {  this.texture = texture; }

    public BasicTile GetTile() {
        if (this.texture == null) { return null; }
        if (this.name == null) { return null; }
        if (this.id == 0) { return null; }
    return new BasicTile(id, name, texture);
    }
}