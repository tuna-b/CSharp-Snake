using System.IO.Compression;

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
                if (i == 0 || i == ROW - 1 || j == 0 || j == COLUMN - 1) {
                    board[i][j] = new Coord(i, j, Coord.CoordType.BORDER);
                } else {
                board[i][j] = new Coord(i, j, Coord.CoordType.EMPTY);
                }
            }
        }
    }
    public void insertSnake(LinkedList<Coord> snakeParts) {
        foreach(Coord snake in snakeParts) {
            board[snake.Row][snake.Col].type = Coord.CoordType.SNAKE;
        }
    }
    public void displayBoard() {
        for(int i = 0; i < ROW; i++) {
            for (int j = 0; j < COLUMN; j++) {
                switch (board[i][j].type) {
                    case Coord.CoordType.FOOD:
                        Console.Write(" o ");
                        break;
                    case Coord.CoordType.EMPTY:
                        Console.Write("   ");
                        break;
                    case Coord.CoordType.SNAKE:
                        Console.Write(" ~ ");
                        break;
                    case Coord.CoordType.BORDER:
                        Console.Write(" # ");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("");
        }
    }
}