public class Coord {
    private readonly int ROW;
    private readonly int COLUMN;
    public int Row {get => ROW;}
    public int Col {get => COLUMN;}
    
    public CoordType type;

    public Coord(int row, int col, CoordType type) {
        this.ROW = row;
        this.COLUMN = col;
        this.type = type;
    }
    public enum CoordType {
        FOOD,
        SNAKE,
        EMPTY,
        BORDER,
    }
   
}