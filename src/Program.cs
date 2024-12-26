class Program {
    static void Main(string[] args) {
        Board board = new Board(10, 10);
        board.initBoard();
        // board.displayBoard();
        Coord head = new Coord(4, 4, Coord.CoordType.SNAKE);
        GameLogic logic = new GameLogic(board, head);
        // logic.updateBoard(0);
        // logic.board.displayBoard();
        // logic.updateBoard(0);
        // logic.board.displayBoard();
        // logic.updateBoard(0);
        // logic.board.displayBoard();
        // logic.updateBoard(0);
        // logic.board.displayBoard();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.CursorVisible = false;
        logic.run();
    }
}