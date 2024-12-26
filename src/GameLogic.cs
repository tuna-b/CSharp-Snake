class GameLogic {
    public Board board;
    private Snake snake;
    private bool gameEnd;
    Coord food;
    bool foodExists;
    public GameLogic(Board board, Coord head) {
        this.board = board;
        snake = new Snake(head);
        foodExists = false;
    }

    public void run() {
        gameEnd = false;
        Console.WriteLine("Press any key to begin!");
        var move = Console.ReadKey();
        var prev = move;

        while (!gameEnd) {
            Thread.Sleep(400);
            if (!foodExists) genFood();
            if (Console.KeyAvailable) {
                move = Console.ReadKey(true);
            }
            // Key press handling
            switch (move.Key) {
                case ConsoleKey.LeftArrow:
                    if (prev.Key != ConsoleKey.RightArrow) updateBoard(0); 
                    else updateBoard(1);
                    break;
                case ConsoleKey.RightArrow:
                    updateBoard(1);
                    break;
                case ConsoleKey.UpArrow:
                    updateBoard(2);
                    break;
                case ConsoleKey.DownArrow:
                    updateBoard(3);
                    break;
            }
            prev = move;
            Console.Clear();
            board.displayBoard();
            gameEnd = checkCollision();
        }
        Console.WriteLine("Final score: " + snake.body.Count);
    }
    public bool updateBoard(int direction) {
        // left = 0, right = 1, up = 1, down = 2
        switch(direction) {
            case 0:
                if (snake.head.Col <= 0) return false;
                snake.head = new Coord(snake.head.Row, snake.head.Col - 1, Coord.CoordType.SNAKE);
                break;
            case 1:
                if (snake.head.Col > board.col - 1) return false;
                snake.head = new Coord(snake.head.Row, snake.head.Col + 1, Coord.CoordType.SNAKE);
                break;
            case 2:
                if (snake.head.Row <= 0) return false;
                snake.head = new Coord(snake.head.Row - 1, snake.head.Col, Coord.CoordType.SNAKE);
                break;
            case 3:
                if (snake.head.Col > board.row - 1) return false;
                snake.head = new Coord(snake.head.Row + 1, snake.head.Col, Coord.CoordType.SNAKE);
                break;
        }
        moveSnake();
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
        food = new Coord(rndRow, rndCol, Coord.CoordType.FOOD);

        board.game[food.Row][food.Col].type = food.type;
        foodExists = true;
    }

    bool snakeEatsFood() {
        if (board.game[snake.head.Row][snake.head.Col].type == Coord.CoordType.FOOD) {
            snake.grow();
            return true;
        } else {
            // updateBoard() method
            return false;
        }
    }

    bool checkCollision() {
        foreach (Coord snakePart in snake.body) {
            if (snake.head.Col == snakePart.Col && snake.head.Row == snakePart.Row) {
                return false;
            }
        }
        // Check if snake goes out of bounds
        return snake.head.Col >= 0 && snake.head.Col < board.col 
                && snake.head.Row > 0 
                && snake.head.Row < board.row;
    }

    void moveSnake() {
        snake.body.AddFirst(snake.head);
        Coord tail = (snake.body.Last != null) ? snake.body.Last.Value : new Coord(0,0,Coord.CoordType.EMPTY);
        board.game[tail.Row][tail.Col].type = Coord.CoordType.EMPTY;
        snake.body.RemoveLast();
        board.insertSnake(snake.body);
    }
}