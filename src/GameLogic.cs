using System.Reflection.Metadata.Ecma335;

class GameLogic {
    public Board board;
    private Snake snake;
    private bool gameEnd;
    Direction direction;
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
        Console.Clear();

        while (!gameEnd) {
            Thread.Sleep(500);
            if (!foodExists) genFood();
            if (Console.KeyAvailable) {
                move = Console.ReadKey(true);
            }
            // Key press handling
            switch (move.Key) {
                case ConsoleKey.LeftArrow:
                    if (direction == Direction.RIGHT) updateBoard((int)Direction.RIGHT);
                    else {
                        direction = Direction.LEFT;
                        gameEnd = updateBoard((int)Direction.LEFT);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (direction == Direction.LEFT) updateBoard((int)Direction.LEFT);
                    else {
                        direction = Direction.RIGHT;
                        gameEnd = updateBoard((int)Direction.RIGHT);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (direction == Direction.DOWN) updateBoard((int)Direction.DOWN);
                    else {
                        direction = Direction.UP;
                        gameEnd = updateBoard((int)Direction.UP);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direction == Direction.UP) updateBoard((int)Direction.UP);
                    else {
                        direction = Direction.DOWN;
                        gameEnd = updateBoard((int)Direction.DOWN);
                    }
                    break;
            }
            Console.SetCursorPosition(0, 0);
            board.displayBoard();
        }
        Console.WriteLine("Game over!\n" + "Final score: " + snake.body.Count);
    }
    // Updates the new position of snakes head based on direction
    public bool updateBoard(int direction) {
        // left = 0, right = 1, up = 2, down = 3
        switch(direction) {
            case 0:
                if (snake.head.Col <= 0) return false;
                snake.head = new Coord(snake.head.Row, snake.head.Col - 1, Coord.CoordType.SNAKE);
                checkSnakeEats();
                break;
            case 1:
                if (snake.head.Col > board.col - 1) return false;
                snake.head = new Coord(snake.head.Row, snake.head.Col + 1, Coord.CoordType.SNAKE);
                checkSnakeEats();
                break;
            case 2:
                if (snake.head.Row <= 0) return false;
                snake.head = new Coord(snake.head.Row - 1, snake.head.Col, Coord.CoordType.SNAKE);
                checkSnakeEats();
                break;
            case 3:
                if (snake.head.Col > board.row - 1) return false;
                snake.head = new Coord(snake.head.Row + 1, snake.head.Col, Coord.CoordType.SNAKE);
                checkSnakeEats();
                break;
        }
        // bool collisionOccured = checkCollision();
        // if (!collisionOccured) moveSnake();
        moveSnake();
        return checkCollision();
    }
        // Generates food at random row and column of board that is initially empty
        void genFood() {
        Random rnd = new Random();
        int rndCol, rndRow;
        while (board.game[rndRow = rnd.Next(0, board.row)][rndCol = rnd.Next(0, board.col)]
                .type != Coord.CoordType.EMPTY) {
                    if (board.game[rndRow][rndCol].type == Coord.CoordType.SNAKE)
                    continue;
        }
        food = new Coord(rndRow, rndCol, Coord.CoordType.FOOD);

        board.game[food.Row][food.Col] = food;
        foodExists = true;
    }

    // Checks if snake head is on food tile, grows snake if true
    bool checkSnakeEats() {
        if (board.game[snake.head.Row][snake.head.Col].type == Coord.CoordType.FOOD) {
            foodExists = false;
            return true;
        }
        return false;
    }

    // Returns true if there is a collision, false if no collision
    // Conditions: snake goes out of borders, or collides with itself
    bool checkCollision() {
        // snake heads column and row
        int row = snake.head.Row;
        int col = snake.head.Col;

        // First expression checks if snake moves out of border, second checks if snake eats itself
        return (row == 0 || row == board.row - 1 || col == board.col - 1 || col == 0)
        ? true
        : snakeEatsItself();
        // snake.body.(snakePart => col == snakePart.Col && row == snakePart.Row);
    }
    
    // Helper method for checkCollision()
    // Checks if snake collides with itself
    bool snakeEatsItself() {
        // since head is at first index, check all other indexes if coords are same:
        for (int i = 1; i < snake.body.Count; i++) {
            Coord snakeCell = snake.body.ElementAt(i);
            if (snakeCell.Col == snake.head.Col && snakeCell.Row == snake.head.Row) return true;
        }
        return false;
    }

    // Moves snake on board
    // removes tail and adds new snake head, it will keep tail if food has been eaten
    void moveSnake() {
        snake.body.AddFirst(snake.head);
        Coord tail = (snake.body.Last != null) ? snake.body.Last.Value : new Coord(0,0,Coord.CoordType.EMPTY);
       
        if (!checkSnakeEats()) {
            board.game[tail.Row][tail.Col].type = Coord.CoordType.EMPTY;
            snake.body.RemoveLast();
        } 
        board.insertSnake(snake.body);
    }
    enum Direction {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
}