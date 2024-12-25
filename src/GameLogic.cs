class GameLogic {
    private Board board;
    private bool gameEnd;
    Coord head;
    public GameLogic(Board board, Coord head) {
        this.board = board;
        this.head = head;
    }

    void run() {
        while (!gameEnd) {

        }
    }
    bool updateBoard(int direction, Coord head) {
        // left = 0, right = 1, up = 1, down = 2
        switch(direction) {
            case 0:
                if (head.Col < 0) return false;
                else {
                }
                break;
            case 1:
                if (head.Col > board.col - 1) return false;
                break;
            case 2:
                if (head.Row < 0) return false;
                break;
            case 3:
                if (head.Col > board.row - 1) return false;
                break;
        }

        return true;
    }

        void genFood() {
        Random rnd = new Random();
        int rndCol, rndRow;
        while (board.game[rndRow = rnd.Next(0, board.row)][rndCol = rnd.Next(0, board.col)]
                .type != Coord.CoordType.EMPTY) {
                    if (board.game[rndRow][rndCol].type == Coord.CoordType.SNAKE)
                    continue;
        }
        board.game[rndRow][rndCol].type = Coord.CoordType.FOOD;
    }
}