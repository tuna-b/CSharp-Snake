public class Board {
    private readonly int COLUMN;
    private readonly int ROW;
    private Coord[][] board;
    public Coord[][] game {get => board; set => this.board = value;}
    public int col {get => COLUMN;}
    public int row {get => ROW;}

    public Board(int row, int col) {
        this.COLUMN = col;
        this.ROW = row;
        board = new Coord[ROW][];
        for (int i = 0; i < COLUMN; i++) {
            board[i] = new Coord[COLUMN];
        }

        initBoard();
    }

    public void initBoard() {
        for(int i = 0; i < ROW; i++) {
            for (int j = 0; j < COLUMN; j++) {
                board[i][j] = new Coord(i, j, Coord.CoordType.EMPTY);
            }
        }
    }
    public void displayBoard() {
        Console.WriteLine("Board:");
        for(int i = 0; i < ROW; i++) {
            for (int j = 0; j < COLUMN; j++) {
                if (board[i][j].type == Coord.CoordType.EMPTY) {
                    Console.Write(" . ");
                } else if (board[i][j].type == Coord.CoordType.FOOD) {
                    Console.Write(" x ");
                } else if (board[i][j].type == Coord.CoordType.SNAKE) {
                    Console.Write(" s ");
                } else {
                    Console.Write(" ? ");
                }
            }
            Console.WriteLine("");
        }
    }
}